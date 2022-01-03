using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour {

    [SerializeField] AchievementDatabase achievementDatabase;
    public bool CleanAchievements = false;
    public AchievementNotificationController achievementNotificationController;

    [SerializeField] GameObject achievementFullScreen;
    [SerializeField] MainController main;
    [SerializeField] Text titleTxt;

    private void Awake () {
        if (CleanAchievements) {
            DeletePlayerPrefs ();
        }
        // ShowAchieved();
        ShowAchievedIncrements();
    }

    void DeletePlayerPrefs() {
        PlayerPrefs.DeleteAll ();
        Debug.Log ("Player Prefs Cleaned! All achievement progress reset complete.");
    }

    void OnEnable () {
        MainController.CurrentScoreChanged += ScoreChanged;
        OrbLauncher.OrbNumberChanged += OrbNumberChanged;
        MainController.Rotator += Rotator;
        LoserLine.GameOver += GameOver;

        PowerUpsController.PowerUpUsed += PowerUpUsed;
        PowerUpsController.FirePowerUpUsed += FirePowerUpUsed;
        PowerUpsController.PlasmaPowerUpUsed += PlasmaPowerUpUsed;
        PowerUpsController.MapKillerPowerUpUsed += MapKillerPowerUpUsed;
        PowerUpsController.TripleShotPowerUpUsed += TripleShotPowerUpUsed;
        PowerUpsController.ElectricityShotPowerUpUsed += ElectricityPowerUpUsed;

        Spawner.OneMoreBlockDestroyed += OneMoreDestroyed;
        Spawner.IcePickedUp += IcePickedUp;
        Spawner.MetalPickedUp += MetalPickedUp;
        Spawner.FlippyFloopPickedUp += FlippyFloopPickedUp;
    }

    void OnDisable () {
        MainController.CurrentScoreChanged -= ScoreChanged;
        OrbLauncher.OrbNumberChanged -= OrbNumberChanged;
        MainController.Rotator -= Rotator;
        LoserLine.GameOver -= GameOver;

        PowerUpsController.PowerUpUsed -= PowerUpUsed;
        PowerUpsController.FirePowerUpUsed -= FirePowerUpUsed;
        PowerUpsController.PlasmaPowerUpUsed -= PlasmaPowerUpUsed;
        PowerUpsController.MapKillerPowerUpUsed -= MapKillerPowerUpUsed;
        PowerUpsController.TripleShotPowerUpUsed -= TripleShotPowerUpUsed;
        PowerUpsController.ElectricityShotPowerUpUsed -= ElectricityPowerUpUsed;

        Spawner.OneMoreBlockDestroyed -= OneMoreDestroyed;
        Spawner.IcePickedUp -= IcePickedUp;
        Spawner.MetalPickedUp -= MetalPickedUp;
        Spawner.FlippyFloopPickedUp -= FlippyFloopPickedUp;
    }

    void ScoreChanged (int score) {
        CheckIncrementalAchievementType (AchievementPropertyType.Levels, score);
    }

    void OrbNumberChanged () {
        CheckIncrementalAchievementType (AchievementPropertyType.Orbs);
    }

    void Rotator () {
        CheckIncrementalAchievementType (AchievementPropertyType.Rotator);
    }

    void GameOver () {
        CheckIncrementalAchievementType (AchievementPropertyType.GameOvers);
    }

    void PowerUpUsed () {
        CheckIncrementalAchievementType (AchievementPropertyType.PowerUps);
    }

    void FirePowerUpUsed () {
        CheckIncrementalAchievementType (AchievementPropertyType.Fire);
    }

    void PlasmaPowerUpUsed () {
        CheckIncrementalAchievementType (AchievementPropertyType.Plasma);
    }

    void MapKillerPowerUpUsed () {
        CheckIncrementalAchievementType (AchievementPropertyType.MapKiller);
    }

    void TripleShotPowerUpUsed () {
        CheckIncrementalAchievementType (AchievementPropertyType.TripleShot);
    }

    void ElectricityPowerUpUsed () {
        CheckIncrementalAchievementType (AchievementPropertyType.Electricity);
    }

    void OneMoreDestroyed () {
        CheckIncrementalAchievementType (AchievementPropertyType.Enemies);
    }

    void IcePickedUp () {
        CheckIncrementalAchievementType (AchievementPropertyType.Ice);
    }

    void MetalPickedUp () {
        CheckIncrementalAchievementType (AchievementPropertyType.Metal);
    }

    void FlippyFloopPickedUp () {
        CheckIncrementalAchievementType (AchievementPropertyType.Flippyfloop);
    }

    void CheckIncrementalAchievementType (AchievementPropertyType type, int amount = 1) {
        foreach (Achievement achievement in achievementDatabase.achievements) {
            if (achievement.property.type == type) {
                if(achievement.property.incrementsAcrossSessions) {
                    amount = PlayerPrefs.GetInt (achievement.id + "SAVED", 0) + 1;
                }

                if (amount >= achievement.property.amount && PlayerPrefs.GetInt (achievement.id, 0) == 0) {
                    UnlockAhievement (achievement);
                }
                else if(string.Equals(achievement.property.type.ToString(), "Levels") == true)
                {
                    amount = SaveSystem.LoadPlayer().highScore;
                    PlayerPrefs.SetInt(achievement.id + "SAVED", amount);
                }
                else {
                    PlayerPrefs.SetInt (achievement.id + "SAVED", amount);
                }
            }
        }
    }

    void UnlockAhievement(Achievement achievement) {
        achievementNotificationController.ShowNotification (achievement);
        PlayerPrefs.SetInt (achievement.id, 1);
        // pause game
        main.JustPause();
        // show achievement fullscreen
        achievementFullScreen.SetActive(true);
        // achievement title
        titleTxt.text = achievement.title;
        // skin image
        // new skin acquired
    }
    
    void ShowAchieved()
    {
        foreach (Achievement achievement in achievementDatabase.achievements)
            Debug.Log(achievement.title + " - " + PlayerPrefs.GetInt(achievement.id));
    }

    void ShowAchievedIncrements()
    {
        foreach (Achievement achievement in achievementDatabase.achievements)
            Debug.Log(achievement.id + " - " + achievement.title + " - " + PlayerPrefs.GetInt(achievement.id + "SAVED"));
    }
}
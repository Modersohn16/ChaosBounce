using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public MainController main;
    public GameObject settingsPanel;
    public GameObject settings;
    public GameObject generalButtons;
    public GameObject howTo;
    public GameObject highScore;
    public GameObject highScoreValue;
    public GameObject currentScore;
    public GameObject currentScoreValue;

    public Text title;
    public LayerMask pauseOn;
    public LayerMask pauseOff;

    //How To Pages
    public GameObject PowerupsMatrix;
    public GameObject BlocksMatrix;
    public GameObject DebrisMatrix;
    public GameObject RandomizersMatrix;

    public void ScoresOff()
    {
        highScoreValue.SetActive(false);
        highScore.SetActive(false);
        currentScoreValue.SetActive(false);
        currentScore.SetActive(false);
    }

    public void ScoresOn()
    {
        highScoreValue.SetActive(true);
        highScore.SetActive(true);
        currentScoreValue.SetActive(true);
        currentScore.SetActive(true);
    }

    public void OpenSettings()
    {
        if (main.paused)
        {
            generalButtons.SetActive(false);
            title.text = "Settings";
            settings.SetActive(true);
            settingsPanel.SetActive (true);
            ScoresOff();
            howTo.SetActive(false);
        }      
    }

    public void OpenGeneralPause()
    {
        if (main.paused)
        {
            settings.SetActive(false);
            settingsPanel.SetActive (false);
            title.text = "Paused";
            generalButtons.SetActive(true);
            howTo.SetActive(false);
            ScoresOn();
        }
    }

    public void OpenHowTwo()
    {
        if (main.paused)
        {
            HowToPagesOff();
            howTo.SetActive(true);
            BlocksMatrix.SetActive(true);
            title.text = "How To play";
            ScoresOff();
            generalButtons.SetActive(false);
            settings.SetActive(false);
            settingsPanel.SetActive (false);
        }
    }

    //How To
    public void OpenHowToMenu()
    {
        HowToPagesOff();
        howTo.SetActive(true);
        BlocksMatrix.SetActive(true);
    }

    public void BlocksToPowerUps()
    {
        HowToPagesOff();
        howTo.SetActive(true);
        PowerupsMatrix.SetActive(true);
    }

    public void PowerToRandom()
    {
        HowToPagesOff();
        howTo.SetActive(true);
        RandomizersMatrix.SetActive(true);
    }

    public void RandomToDebris()
    {
        HowToPagesOff();
        howTo.SetActive(true);
        DebrisMatrix.SetActive(true);
    }

    public void HowToPagesOff()
    {
        DebrisMatrix.SetActive(false);
        RandomizersMatrix.SetActive(false);
        PowerupsMatrix.SetActive(false);
        BlocksMatrix.SetActive(false);
    }
}
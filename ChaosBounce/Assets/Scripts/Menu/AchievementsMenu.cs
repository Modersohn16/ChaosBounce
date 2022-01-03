using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementsMenu : MonoBehaviour {

    public MainController main;
    public GameObject achievements;
    public bool resetHighScore;

    // pages
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;

    // achievement amount texts
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI blocksText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI deathsText;
    public TextMeshProUGUI freezerText;
    public TextMeshProUGUI metallizerText;

    public TextMeshProUGUI firedText;
    public TextMeshProUGUI lightningText;
    public TextMeshProUGUI nukesText;
    public TextMeshProUGUI plasmaText;
    public TextMeshProUGUI tripleshotsText;
    public TextMeshProUGUI rotationsText;

    public TextMeshProUGUI eyesText;
    public TextMeshProUGUI powerupsText;

    // medal images (sprite renderers)
    public Image levelImage;
    public Image blocksImage;
    public Image ammoImage;
    public Image deathsImage;

    public Image iceImage;
    public Image metallizerImage;
    public Image fireImage;
    public Image lightningImage;

    public Image plasmaImage;
    public Image nukesImage;
    public Image tripleshotImage;
    public Image rotatorImage;

    public Image eyeImage;
    public Image powerupImage;

    // medal sprites
    public Sprite[] levelMedals;
    public Sprite[] blocksMedals;
    public Sprite[] fireMedals;
    public Sprite[] eyeMedals;
    public Sprite[] iceMedals;
    public Sprite[] lightningMedals;
    public Sprite[] plasmaMedals;
    public Sprite[] rotatorMedals;
    public Sprite[] metallizerMedals;
    public Sprite[] tripleshotMedals;
    public Sprite[] strokes;

    // medal switch values
    public int[] levelSwitchValues = new int[] { 25, 50, 100, 200, 500, 1000, 2000, 5000};
    public int[] blocksSwitchValues = new int[] { 100, 500, 1000, 2000, 5000, 10000, 20000, 50000};
    public int[] ammoSwitchValues = new int[] { 50, 100, 200, 500, 1000, 2000, 5000, 10000};
    public int[] deathSwitchValues = new int[] { 1, 5, 10, 20, 50, 100, 200, 1000};

    public int[] freezerSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] fireSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] metallizerSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] lightningSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};

    public int[] plasmaSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] nukesSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] tripleshotSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] rotatorSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};

    public int[] eyeSwitchValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000};
    public int[] powerupSwitchValues = new int[] { 25, 50, 100, 200, 500, 1000, 2000, 5000 };

    public void Start()
    {
        if(resetHighScore)
        {
            SaveSystem.ResetHighScore();
        }
    }
    // to be deleted
    public void AchievementsMenuOn()
    {
        if(main.paused)
        {
            achievements.SetActive(true);
        }
    }

    public void ToPage1()
    {
        if(main.paused)
        {
            AllPagesOff();
            page1.SetActive(true);
        }
    }

    public void ToPage2()
    {
        if (main.paused)
        {
            AllPagesOff();
            page2.SetActive(true);
        }
    }

    public void ToPage3()
    {
        if (main.paused)
        {
            AllPagesOff();
            page3.SetActive(true);
        }
    }

    public void ToPage4()
    {
        if (main.paused)
        {
            AllPagesOff();
            page4.SetActive(true);
        }
    }

    public void AllPagesOff()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);

    }

    public void UpdateAchievements()
    {
        // getting numbers (amounts)
        int highScore = SaveSystem.LoadPlayer().highScore;
        int blocks = PlayerPrefs.GetInt("DSTRBLCKS100" + "SAVED");
        int ammo = PlayerPrefs.GetInt("ORBS100" + "SAVED");
        int deaths = PlayerPrefs.GetInt("EARTHDIED1" + "SAVED");

        int freezer = PlayerPrefs.GetInt("PCKUPICE10" + "SAVED");
        int metallizer = PlayerPrefs.GetInt("PCKUPMTL10" + "SAVED");
        int fired = PlayerPrefs.GetInt("FIREUSE10" + "SAVED");
        int lightning = PlayerPrefs.GetInt("LIGHTNINGUSE10" + "SAVED");

        int nukes = PlayerPrefs.GetInt("MAPKILLERUSE10" + "SAVED");
        int plasma = PlayerPrefs.GetInt("PLASMAUSE10" + "SAVED");
        int tripleshots = PlayerPrefs.GetInt("TRPLSHOTUSE10" + "SAVED");
        int rotations = PlayerPrefs.GetInt("PCKUPRTR10" + "SAVED");

        int eyes = PlayerPrefs.GetInt("PCKUPFF10" + "SAVED");
        int powerups = PlayerPrefs.GetInt("CLCTBLPWRP10USE" + "SAVED");

        // achievement numbers text update
        levelText.text = highScore.ToString();
        blocksText.text = blocks.ToString();
        ammoText.text = ammo.ToString();
        deathsText.text = deaths.ToString();

        freezerText.text = freezer.ToString();
        metallizerText.text = metallizer.ToString();
        firedText.text = fired.ToString();
        lightningText.text = lightning.ToString();

        nukesText.text = nukes.ToString();
        plasmaText.text = plasma.ToString();
        tripleshotsText.text = tripleshots.ToString();
        rotationsText.text = rotations.ToString();

        eyesText.text = eyes.ToString();
        powerupsText.text = powerups.ToString();

        // level medal image update
        if(highScore >= levelSwitchValues[7])
        {
            levelImage.sprite = levelMedals[7];
        }
        else if(highScore >= levelSwitchValues[6])
        {
            levelImage.sprite = levelMedals[6];
        }
        else if (highScore >= levelSwitchValues[5])
        {
            levelImage.sprite = levelMedals[5];
        }
        else if (highScore >= levelSwitchValues[4])
        {
            levelImage.sprite = levelMedals[4];
        }
        else if (highScore >= levelSwitchValues[3])
        {
            levelImage.sprite = levelMedals[3];
        }
        else if (highScore >= levelSwitchValues[2])
        {
            levelImage.sprite = levelMedals[2];
        }
        else if (highScore >= levelSwitchValues[1])
        {
            levelImage.sprite = levelMedals[1];
        }
        else if (highScore >= levelSwitchValues[0])
        {
            levelImage.sprite = levelMedals[0];
        }
        else
        {
            levelImage.sprite = strokes[0];
        }

        // block medal image update
        if(blocks >= blocksSwitchValues[7])
        {
            blocksImage.sprite = blocksMedals[7];
        }
        else if(blocks >= blocksSwitchValues[6])
        {
            blocksImage.sprite = blocksMedals[6];
        }
        else if (blocks >= blocksSwitchValues[5])
        {
            blocksImage.sprite = blocksMedals[5];
        }
        else if (blocks >= blocksSwitchValues[4])
        {
            blocksImage.sprite = blocksMedals[4];
        }
        else if (blocks >= blocksSwitchValues[3])
        {
            blocksImage.sprite = blocksMedals[3];
        }
        else if (blocks >= blocksSwitchValues[2])
        {
            blocksImage.sprite = blocksMedals[2];
        }
        else if (blocks >= blocksSwitchValues[1])
        {
            blocksImage.sprite = blocksMedals[1];
        }
        else if (blocks >= blocksSwitchValues[0])
        {
            blocksImage.sprite = blocksMedals[0];
        }
        else
        {
            blocksImage.sprite = strokes[1];
        }

        // ammo medal image update
        if (ammo >= ammoSwitchValues[7])
        {
            ammoImage.sprite = levelMedals[7];
        }
        else if (ammo >= ammoSwitchValues[6])
        {
            ammoImage.sprite = levelMedals[6];
        }
        else if (ammo >= ammoSwitchValues[5])
        {
            ammoImage.sprite = levelMedals[5];
        }
        else if (ammo >= ammoSwitchValues[4])
        {
            ammoImage.sprite = levelMedals[4];
        }
        else if (ammo >= ammoSwitchValues[3])
        {
            ammoImage.sprite = levelMedals[3];
        }
        else if (ammo >= ammoSwitchValues[2])
        {
            ammoImage.sprite = levelMedals[2];
        }
        else if (ammo >= ammoSwitchValues[1])
        {
            ammoImage.sprite = levelMedals[1];
        }
        else if (ammo >= ammoSwitchValues[0])
        {
            ammoImage.sprite = levelMedals[0];
        }
        else
        {
            ammoImage.sprite = strokes[2];
        }

        // death medal image update
        if (deaths >= deathSwitchValues[7])
        {
            deathsImage.sprite = levelMedals[7];
        }
        else if (deaths >= deathSwitchValues[6])
        {
            deathsImage.sprite = levelMedals[6];
        }
        else if (deaths >= deathSwitchValues[5])
        {
            deathsImage.sprite = levelMedals[5];
        }
        else if (deaths >= deathSwitchValues[4])
        {
            deathsImage.sprite = levelMedals[4];
        }
        else if (deaths >= deathSwitchValues[3])
        {
            deathsImage.sprite = levelMedals[3];
        }
        else if (deaths >= deathSwitchValues[2])
        {
            deathsImage.sprite = levelMedals[2];
        }
        else if (deaths >= deathSwitchValues[1])
        {
            deathsImage.sprite = levelMedals[1];
        }
        else if (deaths >= deathSwitchValues[0])
        {
            deathsImage.sprite = levelMedals[0];
        }
        else
        {
            deathsImage.sprite = strokes[3];
        }

        // ice medal image update
        if(freezer >= freezerSwitchValues[7])
        {
            iceImage.sprite = iceMedals[7];
        }
        else if(freezer >= freezerSwitchValues[6])
        {
            iceImage.sprite = iceMedals[6];
        }
        else if (freezer >= freezerSwitchValues[5])
        {
            iceImage.sprite = iceMedals[5];
        }
        else if (freezer >= freezerSwitchValues[4])
        {
            iceImage.sprite = iceMedals[4];
        }
        else if (freezer >= freezerSwitchValues[3])
        {
            iceImage.sprite = iceMedals[3];
        }
        else if (freezer >= freezerSwitchValues[2])
        {
            iceImage.sprite = iceMedals[2];
        }
        else if (freezer >= freezerSwitchValues[1])
        {
            iceImage.sprite = iceMedals[1];
        }
        else if (freezer >= freezerSwitchValues[0])
        {
            iceImage.sprite = iceMedals[0];
        }
        else
        {
            iceImage.sprite = strokes[4];
        }

        // metallizer medal image update
        if (metallizer >= metallizerSwitchValues[7])
        {
            metallizerImage.sprite = metallizerMedals[7];
        }
        else if (metallizer >= metallizerSwitchValues[6])
        {
            metallizerImage.sprite = metallizerMedals[6];
        }
        else if (metallizer >= metallizerSwitchValues[5])
        {
            metallizerImage.sprite = metallizerMedals[5];
        }
        else if (metallizer >= metallizerSwitchValues[4])
        {
            metallizerImage.sprite = metallizerMedals[4];
        }
        else if (metallizer >= metallizerSwitchValues[3])
        {
            metallizerImage.sprite = metallizerMedals[3];
        }
        else if (metallizer >= metallizerSwitchValues[2])
        {
            metallizerImage.sprite = metallizerMedals[2];
        }
        else if (metallizer >= metallizerSwitchValues[1])
        {
            metallizerImage.sprite = metallizerMedals[1];
        }
        else if (metallizer >= metallizerSwitchValues[0])
        {
            metallizerImage.sprite = metallizerMedals[0];
        }
        else
        {
            metallizerImage.sprite = strokes[5];
        }

        // fire medal image update
        if (fired >= fireSwitchValues[7])
        {
            fireImage.sprite = fireMedals[7];
        }
        else if (fired >= fireSwitchValues[6])
        {
            fireImage.sprite = fireMedals[6];
        }
        else if (fired >= fireSwitchValues[5])
        {
            fireImage.sprite = fireMedals[5];
        }
        else if (fired >= fireSwitchValues[4])
        {
            fireImage.sprite = fireMedals[4];
        }
        else if (fired >= fireSwitchValues[3])
        {
            fireImage.sprite = fireMedals[3];
        }
        else if (fired >= fireSwitchValues[2])
        {
            fireImage.sprite = fireMedals[2];
        }
        else if (fired >= fireSwitchValues[1])
        {
            fireImage.sprite = fireMedals[1];
        }
        else if (fired >= fireSwitchValues[0])
        {
            fireImage.sprite = fireMedals[0];
        }
        else
        {
            fireImage.sprite = strokes[6];
        }

        // lightning medal image update
        if (lightning >= lightningSwitchValues[7])
        {
            lightningImage.sprite = lightningMedals[7];
        }
        else if (lightning >= lightningSwitchValues[6])
        {
            lightningImage.sprite = lightningMedals[6];
        }
        else if (lightning >= lightningSwitchValues[5])
        {
            lightningImage.sprite = lightningMedals[5];
        }
        else if (lightning >= lightningSwitchValues[4])
        {
            lightningImage.sprite = lightningMedals[4];
        }
        else if (lightning >= lightningSwitchValues[3])
        {
            lightningImage.sprite = lightningMedals[3];
        }
        else if (lightning >= lightningSwitchValues[2])
        {
            lightningImage.sprite = lightningMedals[2];
        }
        else if (lightning >= lightningSwitchValues[1])
        {
            lightningImage.sprite = lightningMedals[1];
        }
        else if (lightning >= lightningSwitchValues[0])
        {
            lightningImage.sprite = lightningMedals[0];
        }
        else
        {
            lightningImage.sprite = strokes[7];
        }

        // plasma medal image update
        if (plasma >= plasmaSwitchValues[7])
        {
            plasmaImage.sprite = plasmaMedals[7];
        }
        else if (plasma >= plasmaSwitchValues[6])
        {
            plasmaImage.sprite = plasmaMedals[6];
        }
        else if (plasma >= plasmaSwitchValues[5])
        {
            plasmaImage.sprite = plasmaMedals[5];
        }
        else if (plasma >= plasmaSwitchValues[4])
        {
            plasmaImage.sprite = plasmaMedals[4];
        }
        else if (plasma >= plasmaSwitchValues[3])
        {
            plasmaImage.sprite = plasmaMedals[3];
        }
        else if (plasma >= plasmaSwitchValues[2])
        {
            plasmaImage.sprite = plasmaMedals[2];
        }
        else if (plasma >= plasmaSwitchValues[1])
        {
            plasmaImage.sprite = plasmaMedals[1];
        }
        else if (plasma >= plasmaSwitchValues[0])
        {
            plasmaImage.sprite = plasmaMedals[0];
        }
        else
        {
            plasmaImage.sprite = strokes[8];
        }

        // nuke medal image update
        UpdateMedalImage(nukesImage, levelMedals, strokes, nukes, nukesSwitchValues, 9);

        // rotations medal image update
        UpdateMedalImage(rotatorImage, rotatorMedals, strokes, rotations, rotatorSwitchValues, 10);

        // tripleshots medal image update
        UpdateMedalImage(tripleshotImage, tripleshotMedals, strokes, tripleshots, tripleshotSwitchValues, 11);

        // eyes medal image update
        UpdateMedalImage(eyeImage, eyeMedals, strokes, eyes, eyeSwitchValues, 12);

        // powerups medal image update
        UpdateMedalImage(powerupImage, levelMedals, strokes, powerups, powerupSwitchValues, 13);
    }

    void UpdateMedalImage(Image image, Sprite[] medals, Sprite[] strokes, int value, int[] valueSwitch, int strokesNumber)
    {
        if(value >= valueSwitch[7])
        {
            image.sprite = medals[7];
        }
        else if(value >= valueSwitch[6])
        {
            image.sprite = medals[6];
        }
        else if (value >= valueSwitch[5])
        {
            image.sprite = medals[5];
        }
        else if (value >= valueSwitch[4])
        {
            image.sprite = medals[4];
        }
        else if (value >= valueSwitch[3])
        {
            image.sprite = medals[3];
        }
        else if (value >= valueSwitch[2])
        {
            image.sprite = medals[2];
        }
        else if (value >= valueSwitch[1])
        {
            image.sprite = medals[1];
        }
        else if (value >= valueSwitch[0])
        {
            image.sprite = medals[0];
        }
        else
        {
            image.sprite = strokes[strokesNumber];
        }
    }
}

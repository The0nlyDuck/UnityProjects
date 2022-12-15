using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeastDeaths : MonoBehaviour
{
    public GameObject bullyButton;
    private TMPro.TMP_Text changeText;
    private int leastDeaths = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        LeastPlayerDeaths();
        BullyModeActive();
    }

    // Update is called once per frame
    void Update()
    {
        //To close game in main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// Updates the TextMeshPro on the menu to the least amount of deaths
    /// </summary>
    void LeastPlayerDeaths()
    {
        changeText = gameObject.GetComponent<TMPro.TMP_Text>();
        int playerDeaths = 0;

        //bool to check if this is the first time the player has completed the levels
        bool first = PlayerPrefs.HasKey("deaths");
        //gets the player's deaths from the levels
        playerDeaths = PlayerPrefs.GetInt("LeastDeath",0);

        //if false, it is the first time setting the deaths
        if (!first)
        {
            leastDeaths = playerDeaths;
            PlayerPrefs.SetInt("deaths", leastDeaths);
        }
        //else, it checks against the player's least amount of deaths and replaces it if lower
        else
        {
            leastDeaths = PlayerPrefs.GetInt("deaths");
            if (playerDeaths < leastDeaths)
            {
                leastDeaths = playerDeaths;
                PlayerPrefs.SetInt("deaths", leastDeaths);
            }
        }
        changeText.text = leastDeaths.ToString();
    }

    /// <summary>
    /// Checks to see if the player has completed the levels before the bully levels are active
    /// </summary>
    void BullyModeActive()
    {
        if (PlayerPrefs.HasKey("BullyMode"))
        {
            bullyButton.SetActive(true);
        }
    }
}

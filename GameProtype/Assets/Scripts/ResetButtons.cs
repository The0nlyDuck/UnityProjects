using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButtons : MonoBehaviour
{
    /// <summary>
    /// Checks to see if the keys used in options exists and deletes them if they do
    /// </summary>
    public void OptionsReset()
    {
        //Resetting Hardmode Toggle
        if (PlayerPrefs.HasKey("HardMode"))
        {
            PlayerPrefs.DeleteKey("HardMode");
        }

        //Resetting Sensitivtity Slider
        if (PlayerPrefs.HasKey("Sense"))
        {
            PlayerPrefs.DeleteKey("Sense");
        }

        //Resetting Wall and Floor Dropdown Values
        if (PlayerPrefs.HasKey("ColorF"))
        {
            PlayerPrefs.DeleteKey("ColorF");
        }
        if (PlayerPrefs.HasKey("ColorW"))
        {
            PlayerPrefs.DeleteKey("ColorW");
        }

        //Resetting FloorSlider Values
        if (PlayerPrefs.HasKey("RedFloor"))
        {
            PlayerPrefs.DeleteKey("RedFloor");
        }
        if (PlayerPrefs.HasKey("GreenFloor"))
        {
            PlayerPrefs.DeleteKey("GreenFloor");
        }
        if (PlayerPrefs.HasKey("BlueFloor"))
        {
            PlayerPrefs.DeleteKey("BlueFloor");
        }

        //Resetting WallSlider Values
        if (PlayerPrefs.HasKey("RedWall"))
        {
            PlayerPrefs.DeleteKey("RedWall");
        }
        if (PlayerPrefs.HasKey("GreenWall"))
        {
            PlayerPrefs.DeleteKey("GreenWall");
        }
        if (PlayerPrefs.HasKey("BlueWall"))
        {
            PlayerPrefs.DeleteKey("BlueWall");
        }

        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Checks to see if the keys used in player exists and deletes them if they do
    /// </summary>
    public void PlayerDataReset()
    {
        //Resets least Player Deaths
        if (PlayerPrefs.HasKey("LeastDeath"))
        {
            PlayerPrefs.DeleteKey("LeastDeath");
        }
        //Resets to remove Bully Mode
        if (PlayerPrefs.HasKey("BullyMode"))
        {
            PlayerPrefs.DeleteKey("BullyMode");
        }
        
    }

    /// <summary>
    /// Complete reset of all keys
    /// </summary>
    public void FullReset()
    {
        PlayerDataReset();
        OptionsReset();
    }
}

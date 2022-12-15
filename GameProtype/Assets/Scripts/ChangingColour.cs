using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum DropColours
{
    Original,
    Blue,
    Green,
    Red,
    Yellow,
    Custom
}

public class ChangingColour : MonoBehaviour
{
    public Material mainColour, ogColour;
    public Slider rSlider, gSlider, bSlider;

    string dropdownname;
    bool sliderState;
    TMPro.TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<TMPro.TMP_Dropdown>();
        dropdownname = dropdown.gameObject.name;

        //getting the Values for the sliders and dropdown menus
        if (dropdownname == "FloorDropdown")
        {
            rSlider.value = PlayerPrefs.GetFloat("RedFloor", 0);
            gSlider.value = PlayerPrefs.GetFloat("GreenFloor", 0);
            bSlider.value = PlayerPrefs.GetFloat("BlueFloor", 0);

            dropdown.value = PlayerPrefs.GetInt("ColorF", 0);
        }        
        else if (dropdownname == "WallDropdown")
        {
            rSlider.value = PlayerPrefs.GetFloat("RedWall", 0);
            gSlider.value = PlayerPrefs.GetFloat("GreenWall", 0);
            bSlider.value = PlayerPrefs.GetFloat("BlueWall", 0);

            dropdown.value = PlayerPrefs.GetInt("ColorW",0);
        }

        //Adds a listener to the slider and invokes a method when the value changes
        rSlider.onValueChanged.AddListener(delegate { RSlider(); });
        gSlider.onValueChanged.AddListener(delegate { GSlider(); });
        bSlider.onValueChanged.AddListener(delegate { BSlider(); });

        ColourSwitching((DropColours)dropdown.value);
    }

    /// <summary>
    /// Functions that gets called when you select a dropdown option
    /// </summary>
    /// <param name="option">The chosen value from the Dropdown options</param>
    public void ColourChange(int option)
    {
        ColourSwitching((DropColours)option);

        string dropdownname = dropdown.gameObject.name;

        if (dropdownname == "FloorDropdown")
        {
            PlayerPrefs.SetInt("ColorF", option);
        }
        else if (dropdownname == "WallDropdown")
        {
            PlayerPrefs.SetInt("ColorW", option);
        }
    }

    /// <summary>
    /// Function that holds the switch statement for each color change
    /// </summary>
    /// <param name="option">The chosen value from the Dropdown options that is switched to an enum</param>
    public void ColourSwitching(DropColours option)
    {
        TurnOffSlider();
        switch (option)
        {
            case DropColours.Original:
                mainColour.color = ogColour.color;
                break;

            case DropColours.Blue:
                mainColour.color = Color.blue;
                break;

            case DropColours.Green:
                mainColour.color = Color.green;
                break;

            case DropColours.Red:
                mainColour.color = Color.red;
                break;

            case DropColours.Yellow:
                mainColour.color = Color.yellow;
                break;

            case DropColours.Custom:
                TurnOnSlider();
                break;
        }
        
    }

    /// <summary>
    /// Turns off the sliders for custom colors
    /// </summary>
    public void TurnOffSlider()
    {
        //If all are on, it is true, is one or all is off, it is false
        bool redslider = rSlider.gameObject.activeSelf;
        bool greenslider = gSlider.gameObject.activeSelf;
        bool blueslider = bSlider.gameObject.activeSelf;

        if (redslider && greenslider && blueslider)
        {
            rSlider.gameObject.SetActive(false);
            gSlider.gameObject.SetActive(false);
            bSlider.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Turns on the sliders for custom colors
    /// </summary>
    public void TurnOnSlider()
    {
        if (!rSlider.gameObject.activeSelf && !gSlider.gameObject.activeSelf && !bSlider.gameObject.activeSelf)
        {
            rSlider.gameObject.SetActive(true);
            RSlider();
            gSlider.gameObject.SetActive(true);
            GSlider();
            bSlider.gameObject.SetActive(true);
            BSlider();
        }
    }

    /// <summary>
    /// Red's Function Slider when it is changed
    /// </summary>
    public void RSlider()
    {     
        mainColour.color = new Color(rSlider.value, mainColour.color.g, mainColour.color.b);
        if (dropdownname == "FloorDropdown")
        {
            PlayerPrefs.SetFloat("RedFloor", rSlider.value);
        }
        else if (dropdownname == "WallDropdown")
        {
            PlayerPrefs.SetFloat("RedWall", rSlider.value);
        }
    }
    /// <summary>
    /// Green's Function Slider when it is changed
    /// </summary>
    public void GSlider()
    {
        mainColour.color = new Color(mainColour.color.r, gSlider.value, mainColour.color.b);
        if (dropdownname == "FloorDropdown")
        {
            PlayerPrefs.SetFloat("GreenFloor", gSlider.value);
        }
        else if (dropdownname == "WallDropdown")
        {
            PlayerPrefs.SetFloat("GreenWall", gSlider.value);
        }
    }
    /// <summary>
    /// Blue's Function Slider when it is changed
    /// </summary>
    public void BSlider()
    {
        mainColour.color = new Color(mainColour.color.r, mainColour.color.g, bSlider.value);
        if (dropdownname == "FloorDropdown")
        {
            PlayerPrefs.SetFloat("BlueFloor", bSlider.value);
        }
        else if (dropdownname == "WallDropdown")
        {
            PlayerPrefs.SetFloat("BlueWall", bSlider.value);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TurningSense : MonoBehaviour
{
    private float value = 10.0f;
    private TMPro.TMP_Text text;
    private Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        text = gameObject.GetComponentInChildren<TMPro.TMP_Text>();

        if (PlayerPrefs.HasKey("Sense"))
        {
            value = PlayerPrefs.GetFloat("Sense");
            slider.value = value;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        text.text = Convert.ToString(String.Format("{0:0.00}",value));
    }

    /// <summary>
    /// Changes the turning Sensitivity based on the slider it's connected to
    /// </summary>
    /// <param name="sense">The value of the slider</param>
    public void TurningSensitivity(float sense)
    {
        value = sense;
        PlayerPrefs.SetFloat("Sense", sense);
    }
}

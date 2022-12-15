using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardMode : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();

        if (PlayerPrefs.HasKey("HardMode") && PlayerPrefs.GetInt("HardMode") == 1)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    /// <summary>
    /// Activating and Deactiviating Hard Mode based on Toggle it's connected to
    /// </summary>
    /// <param name="mode">Toggle Value</param>
    public void HardModeActivate(bool mode)
    {
        if (mode)
        {
            PlayerPrefs.SetInt("HardMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("HardMode", 0);
        }
    }
}

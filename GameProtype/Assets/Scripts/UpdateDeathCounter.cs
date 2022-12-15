using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDeathCounter : MonoBehaviour
{
    private TMPro.TMP_Text changeText;
    public SphereScript sphereScript;

    // Start is called before the first frame update
    void Start()
    {
        changeText = gameObject.GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        changeText.text = sphereScript.deaths.ToString();
    }
}

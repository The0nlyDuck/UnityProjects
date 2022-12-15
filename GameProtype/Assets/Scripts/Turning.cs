using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    private float deadzone = 0.1f;
    private Vector3 accel = Vector3.zero;
    private Vector3 reset = Vector3.zero;
    private float sensitivity = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Checks and gets sensitvity
        if (PlayerPrefs.HasKey("Sense"))
        {
            sensitivity = PlayerPrefs.GetFloat("Sense");
        }
    }

    /// <summary>
    /// Custom clamp for negative values
    /// </summary>
    /// <param name="angle">The angle to be clamped</param>
    /// <param name="min">The Minimum Value</param>
    /// <param name="max">The Maximum Value</param>
    /// <returns>The Angle Float</returns>
    public static float Clamp(float angle, float min, float max)
    {
        if (angle < 90 || angle > 270)
        {       // if angle in the critic region...
            if (angle > 180) angle -= 360;  // convert all angles to -180..+180
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }
        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }

    /// <summary>
    /// Resets the floor's angles back to 0
    /// </summary>
    public void ResetTurn()
    {
        transform.eulerAngles = reset;
    }

    // Update is called once per frame
    void Update()
    {

        //Keyboard Controls
        float LR = Input.GetAxis("Horizontal");
        float UD = Input.GetAxis("Vertical");

        //Moblie Controls
        accel.x = Input.acceleration.y;
        accel.z = Input.acceleration.x;

        //Deadzone
        if (accel.magnitude < deadzone)
        {
            accel = Vector3.zero;
        }

        //rotate to the left
        if (LR < 0 || accel.z < 0)
        {
            float z = Clamp(transform.eulerAngles.z + (sensitivity * Time.deltaTime), -15f, 15f);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, z);
        }
        //rotate to the right
        if (LR > 0 || accel.z > 0)
        {
            float z = Clamp(transform.eulerAngles.z - (sensitivity * Time.deltaTime), -15f, 15f);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, z);
        }
        //rotate to the forward
        if (UD > 0 || accel.x > 0)
        {
            float x = Clamp(transform.eulerAngles.x + (sensitivity * Time.deltaTime), -15f, 15f);
            transform.rotation = Quaternion.Euler(x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        //rotate to the back
        if (UD < 0 || accel.x < 0)
        {
            float x = Clamp(transform.eulerAngles.x - (sensitivity * Time.deltaTime), -15f, 15f);
            transform.rotation = Quaternion.Euler(x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}

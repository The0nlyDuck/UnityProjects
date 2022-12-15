using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SphereScript : MonoBehaviour
{
    public int deaths = 0;
    public string nxtLv;
    private Rigidbody rb;
    private Vector3 reset;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reset = gameObject.transform.position;
        animator = gameObject.GetComponent<Animator>();

        rb.mass = 5;

        if (PlayerPrefs.HasKey("Player_Deaths"))
        {
            deaths = PlayerPrefs.GetInt("Player_Deaths");
        }

        if (PlayerPrefs.HasKey("HardMode") && PlayerPrefs.GetInt("HardMode") == 1)
        {
            animator.SetBool("SizeChange", true);
        }
        else
        {
            animator.SetBool("SizeChange", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //wakes up the sphere if it ever sleeps
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
    }

    /// <summary>
    /// Reset the Postion and Rigidbody vectors
    /// </summary>
    public void ResetPos()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        this.transform.position = reset;
    }

    /// <summary>
    /// Inbuilt Unity check for when it enters a collision
    /// </summary>
    /// <param name="collision">What the object has collided with</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DeathPlane")
        {
            ResetPos();
            deaths += 1;
        }

        if (collision.gameObject.tag == "VictoryBox")
        {
            if (nxtLv != "Menu")
            {
                PlayerPrefs.SetInt("Player_Deaths", deaths);
            }
            else
            {
                PlayerPrefs.DeleteKey("Player_Deaths");
                PlayerPrefs.SetInt("LeastDeath", deaths);
                PlayerPrefs.SetInt("BullyMode", 1);
            }
            
            SceneManager.LoadScene(nxtLv);
        }
    }
}

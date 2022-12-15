using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bully : MonoBehaviour
{
    public int speed = 2;
    private GameObject toFollow;
    private Rigidbody rb;
    private Vector3 reset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        toFollow = GameObject.FindWithTag("Player");
        reset = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector_to_player = toFollow.transform.position - this.transform.position;

        vector_to_player.Normalize();

        this.transform.forward = vector_to_player;

        this.transform.position = this.transform.position + this.transform.forward * speed * Time.deltaTime;
    }

    /// <summary>
    /// Resets the postion and Rigidbody vectors of the bully
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
    private void OnCollisionEnter(Collision collision)
    {
        //Resets the bully if it hits the death plane
        if (collision.gameObject.name == "DeathPlane")
        {
            ResetPos();
        }
    }
}

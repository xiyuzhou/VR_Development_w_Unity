using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 lastVelocity;
    private Vector3 originalVelocity;
    public bool onGaze = false;
    private bool switcher = false;
    public float fixVelocity = 0.05f;

    void FixedUpdate()
    {
        if (onGaze)
        {
            if (switcher != onGaze)
            {

                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                //GetComponent<Rigidbody>().velocity = fixVelocity * lastVelocity;
                switcher = onGaze;
            }
        }
        else
        {
            if (switcher != onGaze)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().velocity = lastVelocity;
                switcher = onGaze;
            }
            lastVelocity = GetComponent<Rigidbody>().velocity;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
    }
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(0f, 5f);
        originalVelocity = rb.velocity;
    }
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }
}

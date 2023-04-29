using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private Vector3 oldPosition;

    private void Start()
    {
        oldPosition = transform.position;
    }

    private void Update()
    {

        // Shoot a ray between the old and new position to detect collisions
        RaycastHit hit;
        if (Physics.Raycast(oldPosition, transform.position - oldPosition, out hit, (transform.position - oldPosition).magnitude))
        {
            // Handle the collision
            //Debug.Log("Hit: " + hit.collider.name);

            // Destroy the bullet
            if (hit.collider.gameObject.tag == "Ballon")
            {
                var a = hit.collider.gameObject.GetComponent<Pop2>();
                a.onRayCollision(this.gameObject);
                Destroy(gameObject);
            }
            
        }

        // Update the old position
        oldPosition = transform.position;
    }
}

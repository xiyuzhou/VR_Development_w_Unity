using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poppable : MonoBehaviour
{
    public GameObject popEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword" && transform.parent == null && collision.gameObject.GetComponent<Poppable>() == null)
        {
            PopBalloon();
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            PopBalloon();
        }
    }

    private void PopBalloon()
    {
        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1f);
        }
        Destroy(gameObject);
    }
}

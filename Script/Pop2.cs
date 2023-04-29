using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop2: MonoBehaviour
{
    public GameObject popEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var cache = this.GetComponent<HealthBar>();
            if (cache != null)
            {
                if (cache.TakeDamage(collision.gameObject.GetComponent<Bullet>().damage))
                {
                    PopBalloon();
                }
            }
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var cache = this.GetComponent<HealthBar>();
            if (cache != null)
            {
                if (cache.TakeDamage(collision.gameObject.GetComponent<Bullet>().damage))
                {
                    PopBalloon();
                }
            }
            Destroy(collision.gameObject);
        }
    }

    public void onRayCollision(GameObject collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var cache = this.GetComponent<HealthBar>();
            if (cache != null)
            {
                if (cache.TakeDamage(collision.gameObject.GetComponent<Bullet>().damage))
                {
                    PopBalloon();
                }
            }
            Destroy(collision.gameObject);
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

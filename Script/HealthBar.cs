using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform;
    public Slider healthBar;
    private Vector3 offset;

    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Slider>();
        offset = healthBar.transform.position - target.position;
    }

    void LateUpdate()
    {
        healthBar.transform.position = target.position + offset;
        healthBar.transform.LookAt(cameraTransform);
    }

    public bool TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

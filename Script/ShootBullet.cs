using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] bulletSpawnPoints;
    public float bulletSpeed = 10f;
    public float shootDelay = 0.2f;
    public int numBulletsPerShoot = 1;
    public float damage = 10f;
    public float bulletSize = 1f;
    public float maxScatteringAngle = 0f;
    public bool control = false;

    private float lastShotTime;

    private void Update()
    {
        if (control && Time.time - lastShotTime > shootDelay)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < numBulletsPerShoot; i++)
        {
            // Select the current bullet spawn point
            Transform currentBulletSpawnPoint = bulletSpawnPoints[i % bulletSpawnPoints.Length];

            // Set bullet rotation with max scattering angle
            Quaternion randomRotation = Quaternion.Euler(Random.Range(-maxScatteringAngle, maxScatteringAngle), Random.Range(-maxScatteringAngle, maxScatteringAngle), 0);
            Vector3 direction = randomRotation * currentBulletSpawnPoint.forward;

            // Create bullet from prefab at the current spawn point
            GameObject bullet = Instantiate(bulletPrefab, currentBulletSpawnPoint.position, currentBulletSpawnPoint.rotation);

       
            // Set bullet speed
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = direction * bulletSpeed;

            // Set bullet damage and size
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);


            // Destroy the bullet after 3 seconds
            Destroy(bullet, 3f);
        }

    }
    public void triggerActive()
    {
        control = true;
    }

    public void triggerDeactive()
    {
        control = false;
    }
}
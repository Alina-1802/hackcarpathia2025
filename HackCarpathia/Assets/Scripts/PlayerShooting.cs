using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float shootCooldown = 0.2f;

    private float lastShotTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShotTime + shootCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        Vector3 spawnPos = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = Camera.main.transform.forward * bulletForce;
    }
}

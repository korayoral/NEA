using UnityEngine;

public class TowerBev : MonoBehaviour
{
    public Transform firePoint; // Reference for the fire point on the tower
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float baseTimeBetweenShots = 1f; // Base time between shots
    private float timeBetweenShots; // Current time between shots
    private bool isEnemyInRange; // Flag to track if an enemy is within range

    void Start()
    {
        // Set initial time between shots
        timeBetweenShots = baseTimeBetweenShots;
    }

    void Update()
    {
        // Decrease the time between shots
        timeBetweenShots -= Time.deltaTime * WaveSpawner.scale;

        if (isEnemyInRange && timeBetweenShots <= 0)
        {
            // Shoot
            Shoot();
            // Reset the time between shots
            timeBetweenShots = baseTimeBetweenShots;
        }
    }

    void Shoot()
    {
        // Instantiate a projectile at the fire point
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided GameObject has the tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            isEnemyInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collided GameObject has the tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            isEnemyInRange = false;
        }
    }
}

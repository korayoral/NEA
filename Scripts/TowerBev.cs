using UnityEngine;

public class TowerBev : MonoBehaviour
{
    public Transform firePoint; // Reference for the fire point on the tower
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float timeBetweenShots = 1f; // Time between shots
    private float currentTimeBetweenShots; // Current time between shots
    private bool isEnemyInRange; // Flag to track if an enemy is within range

    void Start()
    {
        currentTimeBetweenShots = timeBetweenShots;
    }

    void Update()
    {
        if (isEnemyInRange)
        {
            // Decrease the time between shots
            currentTimeBetweenShots -= Time.deltaTime;

            // Check if it's time to shoot
            if (currentTimeBetweenShots <= 0)
            {
                // Shoot
                Shoot();
                // Reset the time between shots
                currentTimeBetweenShots = timeBetweenShots;
            }
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

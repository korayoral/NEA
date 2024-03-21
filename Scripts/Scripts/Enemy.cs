using UnityEngine;

public class EnemyBev : MonoBehaviour
{
    public static float health=5f;
    public static float speed=1.5f;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        // Set initial target to the first waypoint
        SetNextWaypoint();

        // Adjust health and speed based on scale
        health += WaveSpawner.scale * 0.05f;
        speed += WaveSpawner.scale * 0.01f;
    }

    void Update()
    {
        // If target is not null, move towards it
        if (target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            // Check if the enemy has reached the target waypoint
            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                // Set the next waypoint as the target
                SetNextWaypoint();
            }
        }
    }

    // Function to set the next waypoint as the target
    void SetNextWaypoint()
    {
        // Check if there are waypoints available
        if (Waypoints.waypoints.Length > 0)
        {
            // Increment the waypoint index
            wavepointIndex++;

            // Check if the incremented index is within the bounds of the waypoints array
            if (wavepointIndex < Waypoints.waypoints.Length)
            {
                // Set the next waypoint as the target
                target = Waypoints.waypoints[wavepointIndex];
            }
            else
            {
                // If the index is out of bounds, destroy the enemy
                Destroy(gameObject);
                ScoreManager.health -= 25;
            }
        }
    }
}

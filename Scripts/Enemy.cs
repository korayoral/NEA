using UnityEngine;

public class EnemyBev : MonoBehaviour
{
    public  GameObject enemyObject;
    public  float health;
    public  float speed;
    private Transform target;
    private int wavepointIndex = 0;
    public static bool DoDamage = false;
    public float damage;


    void Start()
    {
        // Set initial target to the first waypoint
        SetNextWaypoint();
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
                DoDamage = true;
                DesEnemy(enemyObject);
               
            }
        }
    }

    public static void DesEnemy(GameObject enemyObject)    //hi
    {
        Destroy(enemyObject);
   
    }




}

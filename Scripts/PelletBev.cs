using UnityEngine;

public class PelletBev : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject enemyObject;

    void Start()
    {
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyObject != null)
        {
            target = enemyObject.transform;
        }
        else
        {
            Debug.LogError("No enemy found with the 'Enemy' tag.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                DestroyProjectile(enemyObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile(other.gameObject);
        }
    }

    void DestroyProjectile(GameObject enemy)
    {
        Destroy(enemy);
        Destroy(gameObject);
    }
}

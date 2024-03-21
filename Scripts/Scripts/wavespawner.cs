using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public static float scale;
    float x = Mathf.Pow(0.5f, 2);

    // List to keep track of spawned enemies
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        Debug.Log("Wave Incoming!");

        for (int i = 0; i < waveIndex; i++)
        {
            // Spawn enemy at the spawnPoint
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedEnemies.Add(enemyInstance);
            yield return new WaitForSeconds(0.5f);  // Delay between enemy spawns
        }

        // Update money in ScoreManager
        ScoreManager.money += 20 + waveIndex * 100;
        scale += waveIndex * x + 50;
    }

    // Destroying a specific cloned GameObject
    void DestroyEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            // Check if the enemy has a specific tag or identifier
            if (enemy.CompareTag("ClonedEnemy"))
            {
                spawnedEnemies.Remove(enemy);
                Destroy(enemy);
            }
            else
            {
                Debug.Log("This is not a cloned enemy. Skipping destruction.");
            }
        }
    }
}

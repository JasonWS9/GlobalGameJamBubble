using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;  // The enemy prefab to spawn.
    public int maxEnemies = 10;     // The maximum number of enemies to spawn.
    public float spawnInterval = 2.0f; // The time between enemy spawns.
    public float lowerBoundFromPlayer;
    public float upperBoundFromPlayer;
    

    public float upperBoundY;
    public float upperBoundX;
    public float lowerBoundY;
    public float lowerBoundX;

    private Transform spawnPoint;
    private float timer = 0.0f;
    private Vector2 spawnPosition = new Vector2();
    private int enemyCount = 0;

    void Start()
    {
        spawnPoint = player.transform; // Use the position of this GameObject as the spawn point.
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
        if (enemyCount < maxEnemies && timer >= spawnInterval)
        {
            float radius = 0;
            while (Mathf.Abs(radius) < lowerBoundFromPlayer)
                radius = Random.Range(-upperBoundFromPlayer, upperBoundFromPlayer);

            Vector2 randomPosition = Random.insideUnitCircle * radius;
            // spawnPosition = spawnPoint.position + new Vector3(randomPosition.x, randomPosition.y);
            do {
                spawnPosition = new Vector3(0, 0, 0) + new Vector3(randomPosition.x, randomPosition.y);
            } while (spawnPosition.x > upperBoundX || spawnPosition.x < lowerBoundX || spawnPosition.y > upperBoundY || spawnPosition.y < lowerBoundY);
            
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyCount++;
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }

    public static void spawnEnemies()
    {
        
    }
}

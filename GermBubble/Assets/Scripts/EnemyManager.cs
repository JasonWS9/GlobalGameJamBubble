using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    [FormerlySerializedAs("enemyPrefab")] public GameObject bubbleEnemyPrefab;  // The enemy prefab to spawn.
    public int maxEnemies = 10;     // The maximum number of enemies to spawn.
    public float spawnInterval = 2.0f; // The time between enemy spawns.
    public float lowerBoundFromPlayer; // Lowest spawn position from the player
    public float upperBoundFromPlayer; // Highest spawn position from the player
    
    public float upperBoundY; // Maximum y position of enemy
    public float upperBoundX; // Maximum x position of enemy
    public float lowerBoundY; // Minimum y position of enemy
    public float lowerBoundX; // Minimum x position of enemy
    
    private float timer = 0.0f;
    private Vector2 spawnPosition;
    public int enemyCount = 0;

    public static EnemyManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }

    void Update()
    {
        // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
        if (enemyCount < maxEnemies && timer >= spawnInterval)
        {
            bool validSpawn = false;

            while (!validSpawn)
            {
                // Generate a random position within a circle around the player.
                float radius = Random.Range(lowerBoundFromPlayer, upperBoundFromPlayer);
                Vector2 randomPosition = Random.insideUnitCircle.normalized * radius;
                spawnPosition = (Vector2)player.transform.position + randomPosition;

                // Clamp the position to the stage boundaries.
                spawnPosition.x = Mathf.Clamp(spawnPosition.x, lowerBoundX, upperBoundX);
                spawnPosition.y = Mathf.Clamp(spawnPosition.y, lowerBoundY, upperBoundY);

                // Ensure the spawn position is still outside the safe zone around the player.
                float distanceFromPlayer = Vector2.Distance(spawnPosition, player.transform.position);
                if (distanceFromPlayer >= lowerBoundFromPlayer)
                {
                    validSpawn = true;
                }
            }

            // Instantiate the enemy at the valid position.
            Instantiate(bubbleEnemyPrefab, spawnPosition, Quaternion.identity);

            // Increment the enemy count and reset the timer.
            enemyCount++;
            timer = 0.0f;
        }

        // Update the timer.
        timer += Time.deltaTime;
    }

}


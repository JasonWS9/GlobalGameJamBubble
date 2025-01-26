// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Serialization;

// public class EnemyManager : MonoBehaviour
// {
//     public GameObject player;
//     public GameObject bubbleEnemyPrefab;  // The enemy prefab to spawn.
//     public GameObject FoamEnemyPrefab;
//     public int maxEnemies = 10;     // The maximum number of enemies to spawn.
//     public float spawnInterval = 2.0f; // The time between enemy spawns.
//     public float lowerBoundFromPlayer; // Lowest spawn position from the player
//     public float upperBoundFromPlayer; // Highest spawn position from the player
    
//     public float upperBoundY; // Maximum y position of enemy
//     public float upperBoundX; // Maximum x position of enemy
//     public float lowerBoundY; // Minimum y position of enemy
//     public float lowerBoundX; // Minimum x position of enemy
    
//     private float timer = 0.0f;
//     private Vector2 spawnPosition;
//     public int enemyCount = 0;

//     public int wave = 1;
//     public bool upgradeWave = false;
//     private int spawnedEnemies = 0;
    

//     public static EnemyManager Instance;


//     void Awake()
//     {
//         if (Instance == null)
//             Instance = this;
//         else
//             Destroy(this);
//     }

//     void Update()
//     {
//         if(upgradeWave)
//         {
//             wave++;
//             upgradeWave = false;
//         }
            
//         switch(wave)
//         {
//             case 1:
//                 spawnEnemiesForWave1();
//                 break;
//             case 2:
//                 spawnEnemiesForWave2();
//                 break;
//             case 3:
//                 spawnEnemiesForWave3();
//                 break;
//         }
        
//         // Update the timer.
//         timer += Time.deltaTime;
//     }

//     private void getValidSpawnPosition()
//     {
//         bool validSpawn = false;
//         while (!validSpawn)
//         {
//             // Generate a random position within a circle around the player.
//             float radius = Random.Range(lowerBoundFromPlayer, upperBoundFromPlayer);
//             Vector2 randomPosition = Random.insideUnitCircle.normalized * radius;
//             spawnPosition = (Vector2)player.transform.position + randomPosition;

//             // Clamp the position to the stage boundaries.
//             spawnPosition.x = Mathf.Clamp(spawnPosition.x, lowerBoundX, upperBoundX);
//             spawnPosition.y = Mathf.Clamp(spawnPosition.y, lowerBoundY, upperBoundY);

//             // Ensure the spawn position is still outside the safe zone around the player.
//             float distanceFromPlayer = Vector2.Distance(spawnPosition, player.transform.position);
//             if (distanceFromPlayer >= lowerBoundFromPlayer)
//             {
//                 validSpawn = true;
//             }
//         }
//     }

//     void spawnEnemiesForWave1()
//     {
//         // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
//         if (enemyCount < maxEnemies && timer >= spawnInterval)
//         {
//             getValidSpawnPosition();

//             // Instantiate the enemy at the valid position.
//             Instantiate(bubbleEnemyPrefab, spawnPosition, Quaternion.identity);

//             // Increment the enemy count and reset the timer.
//             spawnedEnemies++;
//             enemyCount++;
//             timer = 0.0f;
//         }

//         if(spawnedEnemies >= 5)
//         {
//             spawnedEnemies = 0;
//             upgradeWave = true;
//             Debug.Log("Changing from wave 1 to 2.");
//         }

//     }

//     void spawnEnemiesForWave2()
//     {
//         // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
//         if (enemyCount < maxEnemies && timer >= spawnInterval - 0.3)
//         {
//             getValidSpawnPosition();

//             // Instantiate the enemy at the valid position.
//             Instantiate(bubbleEnemyPrefab, spawnPosition, Quaternion.identity);

//             // Increment the enemy count and reset the timer.
//             spawnedEnemies++;
//             enemyCount++;
//             timer = 0.0f;
//         }

//         if(spawnedEnemies >= 5)
//         {
//             spawnedEnemies = 0;
//             upgradeWave = true;
//             Debug.Log("Changing from wave 1 to 2.");
//         }

//     }

//     void spawnEnemiesForWave3()
//     {
//         // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
//         if (enemyCount < maxEnemies && timer >= spawnInterval - 0.6)
//         {
//             getValidSpawnPosition();
            
//             int random = Random.Range(1, 3);
//             switch(random)
//             {
//                 case 1:
//                     Instantiate(bubbleEnemyPrefab, spawnPosition, Quaternion.identity);
//                     break;
//                 case 2:
//                     Instantiate(FoamEnemyPrefab, spawnPosition, Quaternion.identity);
//                     break;
//             }

//             // Increment the enemy count and reset the timer.
//             spawnedEnemies++;
//             enemyCount++;
//             timer = 0.0f;
//         }

//         if(spawnedEnemies >= 10)
//         {
//             spawnedEnemies = 0;
//             //upgradeWave = true;
//             Debug.Log("Should change from wave 2 to 3.");
//         }
//     }

//     void spawnEnemiesForWave4()
//     {
//         // Check if it's time to spawn a new enemy and if we haven't reached the maximum enemy count.
//         if (enemyCount < maxEnemies && timer >= spawnInterval)
//         {
//             getValidSpawnPosition();
            
//             int random = Random.Range(1,3);
//             switch(random)
//             {
//                 case 1:
//                     Instantiate(bubbleEnemyPrefab, spawnPosition, Quaternion.identity);
//                     break;
//                 case 2:
//                     Instantiate(FoamEnemyPrefab, spawnPosition, Quaternion.identity);
//                     break;
//             }

//             // Increment the enemy count and reset the timer.
//             spawnedEnemies++;
//             enemyCount++;
//             timer = 0.0f;
//         }

//         if(spawnedEnemies >= 20)
//         {
//             spawnedEnemies = 0;
//             //upgradeWave = true;
//         }
//     }

// }






using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject bubbleEnemyPrefab;
    public GameObject foamEnemyPrefab;

    [Header("Spawn Settings")]
    public int initialMaxEnemies = 10;      // Initial maximum number of enemies.
    public float initialSpawnInterval = 2.0f; // Initial spawn interval.
    public float spawnIntervalDecay = 0.05f; // How much the spawn interval decreases per wave.
    public int enemiesPerWaveIncrease = 2; // How many more enemies to spawn each wave.
    public float healthPerWaveIncrease = 5f;

    [Header("Bounds")]
    public float lowerBoundFromPlayer;
    public float upperBoundFromPlayer;
    public float upperBoundY;
    public float upperBoundX;
    public float lowerBoundY;
    public float lowerBoundX;

    private float timer;
    private Vector2 spawnPosition;
    public int enemyCount;
    public int wave = 1;
    private int spawnedEnemies;
    private float currentSpawnInterval;
    private int currentMaxEnemies;
    private float currentEnemyHealth;

    public static EnemyManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        // Initialize spawn settings.
        currentSpawnInterval = initialSpawnInterval;
        currentMaxEnemies = initialMaxEnemies;
    }

    void Update()
    {
        HandleWaveProgression();
        SpawnEnemiesForCurrentWave();
        timer += Time.deltaTime;
    }

    private void HandleWaveProgression()
    {
        if (spawnedEnemies >= currentMaxEnemies)
        {
            wave++;
            spawnedEnemies = 0;

            // Make the game progressively harder.
            currentSpawnInterval = Mathf.Max(0.5f, currentSpawnInterval - spawnIntervalDecay); // Lower limit on spawn interval.
            currentMaxEnemies += enemiesPerWaveIncrease;
            currentEnemyHealth += healthPerWaveIncrease;

            Debug.Log($"Wave {wave} started. Spawn Interval: {currentSpawnInterval:F2}, Max Enemies: {currentMaxEnemies}");
        }
    }

    private void SpawnEnemiesForCurrentWave()
    {
        if (enemyCount < currentMaxEnemies && timer >= currentSpawnInterval)
        {
            GetValidSpawnPosition();
            SpawnRandomEnemy();
            timer = 0.0f;
        }
    }

    private void GetValidSpawnPosition()
    {
        bool validSpawn = false;
        while (!validSpawn)
        {
            float radius = Random.Range(lowerBoundFromPlayer, upperBoundFromPlayer);
            Vector2 randomPosition = Random.insideUnitCircle.normalized * radius;
            spawnPosition = (Vector2)player.transform.position + randomPosition;

            spawnPosition.x = Mathf.Clamp(spawnPosition.x, lowerBoundX, upperBoundX);
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, lowerBoundY, upperBoundY);

            if (Vector2.Distance(spawnPosition, player.transform.position) >= lowerBoundFromPlayer)
                validSpawn = true;
        }
    }

    private void SpawnRandomEnemy()
    {
        // Randomly decide which enemy type to spawn.
        GameObject prefab = Random.Range(0, 2) == 0 ? bubbleEnemyPrefab : foamEnemyPrefab;
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        // prefab.EnemyFollowScript.health = currentEnemyHealth;
        spawnedEnemies++;
        enemyCount++;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Defines how many more enemies will this point spawn
    /// </summary>
    public float AddMoreEnemies = 3f;

    /// <summary>
    /// Defines delay to wait between new enemies
    /// </summary>
    public float DelayBetweenEnemies = 3f;

    /// <summary>
    /// Stores time when last enemy was spawned
    /// </summary>
    private float elapsedTime;

    /// <summary>
    /// Number of seconds to wait before spawning the first enemy. Allows some time for the  player to get away from a new spawn point.
    /// </summary>
    private float initialSpawnDelay = 3f;

    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Store the time when the spawner was created and add some initial delay to spawning the first enemy
        elapsedTime = Time.time + initialSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // If spawner has additional enemies to spawn and the time delay has elapsed
        if (AddMoreEnemies > 0 && Time.time - elapsedTime > DelayBetweenEnemies)
        {
            SpawnNewEnemy();
            AddMoreEnemies--;
            elapsedTime = Time.time;
        }

        if (AddMoreEnemies < 1)
        {
            // No more enemies to spawn, die now
            Destroy(gameObject);
        }
    }

    void SpawnNewEnemy()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
    }
}

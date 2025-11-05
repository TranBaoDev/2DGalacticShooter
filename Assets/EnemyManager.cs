using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _spawners;

    private float _spawnInterval = 1.0f; // Time between enemy spawns (in seconds)
    private float _spawnTimer = 0.0f;    // Countdown timer for spawning

    void Start()
    {
        // Get all enemy spawner objects in the scene
        var spawnerList = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

        foreach (var spawner in spawnerList)
        {
            _spawners.Add(spawner);
        }
    }

    void Update()
    {
        // Check if it's time to spawn a new enemy
        if (_spawnTimer >= _spawnInterval)
        {
            // Choose a random spawner index
            int index = Random.Range(0, _spawners.Count);

            // Spawn a random enemy from the list of spawners
            _spawners[index].Spawn();

            // Reset timer
            _spawnTimer = 0.0f;
        }
        else
        {
            // Increase timer by the time since the last frame
            _spawnTimer += Time.deltaTime;
        }
    }
}

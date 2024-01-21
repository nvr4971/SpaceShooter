using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Wave")]
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private int currentWave;
    [SerializeField] private int waveValue;
    [SerializeField] private List<GameObject> enemiesToSpawn;

    [Header("Spawner")]
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private float waveDuration;
    private float waveTimer;
    [SerializeField] private float spawnInterval;
    private float spawnTimer;


    private void Start()
    {
        GenerateWave();
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            // Spawn an enemy

            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.deltaTime;
            waveTimer -= Time.deltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost

        // repeat...

        // -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new();

        while (waveValue > 0)
        {
            int randomEnemyId = Random.Range(0, enemyList.Count);
            int randomEnemyCost = enemyList[randomEnemyId].cost;

            if (waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemyList[randomEnemyId].enemyPrefab);
                waveValue -= randomEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
    }
}

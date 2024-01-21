using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance { get; private set; }

    [Header("Enemy List")]
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<Enemy> toSpawnList;

    [Header("Wave Data")]
    [SerializeField] private int waveCount;
    private int waveCredit;

    [Header("Wave Active Data")]
    [SerializeField] private int waveMaxActivePerRow;
    [SerializeField] private int waveActiveEnemy;
    private int waveMaxActive;

    [Header("Timer")]
    [SerializeField] private float spawnInterval;
    [SerializeField] private float waveInterval;
    private float spawnTimer;

    [Header("Row State")]
    [SerializeField] private List<Transform> rows; 

    private void Awake()
    {
        if (EnemySpawn.Instance != null)
        {
            Destroy(EnemySpawn.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        waveCount = 1;
        waveMaxActive = waveMaxActivePerRow * rows.Count;
        ResetData();
    }

    private void ResetData()
    {
        // Set credit and reset wave data
        ResetWaveData();
        // Generate Enemy Wave
        GenerateWave();
    }

    private void Update()
    {
        if (toSpawnList.Count > 0)
        {
            spawnTimer += Time.deltaTime;

            Transform row = GetValidRow();

            if (waveActiveEnemy < waveMaxActive && spawnTimer > spawnInterval && row)
            {
                ProcessSpawn(row);

                spawnTimer = 0;
            }
        }
    }

    public void UpdateActiveEnemyCount()
    {
        waveActiveEnemy -= 1;

        if (toSpawnList.Count <= 0 && waveActiveEnemy == 0)
        {
            StartCoroutine(NextWave());
        }
    }

    IEnumerator NextWave()
    {
        waveCount++;

        yield return new WaitForSeconds(waveInterval);

        ResetData();
    }

    private Transform GetValidRow()
    {
        List<Transform> lst = rows;
        Shuffle(lst);

        foreach (Transform row in lst)
        {
            if (row.GetComponent<RowCount>().GetRowEnemyCount() < waveMaxActivePerRow)
            {
                return row;
            }
        }

        return null;
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        System.Random rnd = new();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void ProcessSpawn(Transform row)
    {
        // Spawn
        GameObject go = Instantiate(toSpawnList[0].enemyPrefab, transform.position, Quaternion.identity, row);
        go.GetComponent<EnemyGroupMovement>().SetRowParent(row);

        // Pop toSpawn list
        toSpawnList.RemoveAt(0);

        // Update active enemy count
        waveActiveEnemy += go.transform.childCount;
    }

    private void ResetWaveData()
    {
        waveCredit = waveCount * 2;
        toSpawnList.Clear();
        waveActiveEnemy = 0;
        spawnTimer = 0;
    }

    private void GenerateWave()
    {
        while (waveCredit > 0)
        {
            // Get random enemy ID and cost
            int randomId = Random.Range(0, enemyList.Count);
            int randomCost = enemyList[randomId].cost;

            // If affordable, add enemy to toSpawnList, deduct credit and update waveEnemyCount
            if (waveCredit - randomCost >= 0)
            {
                toSpawnList.Add(enemyList[randomId]);
                waveCredit -= randomCost;
            }
            else
            {
                if (waveCredit <= 0)
                {
                    break;
                }
            }
        }
    }
}

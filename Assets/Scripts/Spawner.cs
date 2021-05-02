using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; set; }
    public List<Transform> enemySpawnPositions;
    public List<EnemySO> enemyWaves;
    public GameObject enemyPrefab;
    public int currentWave = 0;

    public List<GameObject> enemiesSpawn;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        EnemySpawn();
    }
    private void Update()
    {

    }
    public void EnemySpawn()
    {
        for (int i = 0; i < enemyWaves[currentWave].amountToSpawn; i++)
        {
            GameObject en = Instantiate(enemyPrefab, enemySpawnPositions[i]);
            en.GetComponent<Enemy>().SetUp(enemyWaves[currentWave]);
            enemiesSpawn.Add(en);
        }
    }

    public void RemoveEmptyEnemies()
    {
        enemiesSpawn.RemoveAll(obj => obj == null);
        //enemiesSpawn.TrimExcess();
    }
    public void CheckAllEnemiesAreDead(GameObject go)
    {
        enemiesSpawn.Remove(go);
        Destroy(go);
        enemiesSpawn = enemiesSpawn.Where(item => item != null).ToList();
        if (enemiesSpawn.Count <= 0)
        {
            currentWave++;
            EnemySpawn();
        }
    }
}

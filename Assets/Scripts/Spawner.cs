using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> enemySpawnPositions;
    public List<EnemySO> enemyWaves;
    public GameObject enemyPrefab;
    private int currentWave = 0;

    void Start()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < enemyWaves[currentWave].amountToSpawn; i++)
        {
            GameObject en = Instantiate(enemyPrefab, enemySpawnPositions[i]);
            en.GetComponent<Enemy>().SetUp(enemyWaves[currentWave]);
        }
    }
}

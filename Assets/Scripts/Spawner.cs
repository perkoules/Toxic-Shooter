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
    public GameObject endGamePanel;
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

    public void EnemySpawn()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        if (currentWave < enemyWaves.Count)
        {
            for (int i = 0; i < enemyWaves[currentWave].amountToSpawn; i++)
            {
                GameObject en = Instantiate(enemyPrefab, enemySpawnPositions[i]);
                en.GetComponent<Enemy>().SetUp(enemyWaves[currentWave]);
                enemiesSpawn.Add(en);
            }
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        endGamePanel.SetActive(true);
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

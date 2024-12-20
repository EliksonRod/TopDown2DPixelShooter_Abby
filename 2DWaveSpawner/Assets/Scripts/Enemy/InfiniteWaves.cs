using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]

public class InfiniteWaves : MonoBehaviour
{
    public int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public int enemiesKilled = 0;

    public GameObject[] spawners;
   // public GameObject enemy;

    public GameObject[] typeOfEnemies;


    private void Start()
    {
        spawners = new GameObject[4];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnEnemy();
        }
        if(enemiesKilled >= enemySpawnAmount)
        {
            NextWave();
        }
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

    }
    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        //Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);

        GameObject randomEnemy = typeOfEnemies[Random.Range(0, typeOfEnemies.Length)];
        Instantiate(randomEnemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }
    private void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmount = 5;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++ )
        {

            SpawnEnemy();

        }
    }
    public void NextWave()
    {
        waveNumber++;
        enemySpawnAmount += 3;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
}


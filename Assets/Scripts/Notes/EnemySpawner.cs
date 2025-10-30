using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnRate = 1.5f;
    private float timeBetweenWaves = 3.0f;

    public int enemyCount;
    bool canSpawn;

    bool waveIsDone = true;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(spawnEnemy(spawnRate, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
    private void Update()
    {
        if(waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }
    private IEnumerator waveSpawner()
    {
        waveIsDone = false;

        //Spawn One Wave

        if (enemyCount >= 200)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
        if (canSpawn == true) { 
            for (int i = 0; i <= enemyCount; i++)
            {
                GameObject enemyClone = Instantiate(enemyPrefab);

                //Delay between spawning
                yield return new WaitForSeconds(spawnRate);

                //Makes waves after harder
                spawnRate -= 0.15f;
                enemyCount += 4;
            }
        }
    }
}
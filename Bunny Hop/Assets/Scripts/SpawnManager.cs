using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject enemyPrefab;

    private float xBound;
    private float zBound;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider groundBC = GameObject.Find("Ground").GetComponent<BoxCollider>();

        xBound = groundBC.size.x;
        zBound = groundBC.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        int numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        int numFood = GameObject.FindGameObjectsWithTag("Food").Length;

        if (numEnemies == 0)
        {
            SpawnEnemy();
        }

        if (numFood == 0)
        {
            SpawnFood();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, RandomSpawnPosition(), enemyPrefab.transform.rotation);
    }

    void SpawnFood()
    {
        Instantiate(foodPrefab, RandomSpawnPosition(), foodPrefab.transform.rotation);
    }

    private Vector3 RandomSpawnPosition()
    {
        float randomX = Random.Range(-xBound, xBound);
        float randomZ = Random.Range(-zBound, zBound);

        Vector3 spawnPos = new Vector3(randomX, 0, randomZ);
        return spawnPos;
    }

}

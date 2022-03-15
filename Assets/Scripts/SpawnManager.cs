using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject[] Coins;
    private float zRange = 18f;
    private float xRange = 32f;
    private float startTime = 1f;
    private float repeatRate = 3f;
    private float startTime2 = 10f;
    private float repeatRate2 = 10f;

    private Enemy enemyScript;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, repeatRate);
        InvokeRepeating("SpawnCoins", startTime2, repeatRate2);
    }
    public Vector3 RandomSpawnPosition()
    {
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);
        return new Vector3(randomX, 0, randomZ);
    }
    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[randomIndex], RandomSpawnPosition(),
        Enemies[randomIndex].transform.rotation);
    }

    public void SpawnCoins()
    {
        int randomIndex = Random.Range(0, Coins.Length);
        Instantiate(Coins[randomIndex], RandomSpawnPosition(),
        Coins[randomIndex].transform.rotation);
    }
}

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
    private float startTime2 = 5f;
    private float repeatRate2 = 5f;

    private GameManager gameManagerScript;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, repeatRate);
        InvokeRepeating("SpawnCoins", startTime2, repeatRate2);
        gameManagerScript = FindObjectOfType<GameManager>();
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
        if (!gameManagerScript.gameOver)
        {
            Instantiate(Enemies[randomIndex], RandomSpawnPosition(),
        Enemies[randomIndex].transform.rotation);
        }
    }

    public void SpawnCoins()
    {
        int randomIndex = Random.Range(0, Coins.Length);
        if (!gameManagerScript.gameOver)
        {
            Instantiate(Coins[randomIndex], RandomSpawnPosition(),
        Coins[randomIndex].transform.rotation);
        }
    }
}

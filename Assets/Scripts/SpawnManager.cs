using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject[] PowerUps;
    private float zRange = 18f;
    private float xRange = 32f;
    private float startTime = 1f;
    private float repeatRate = 3f;
    private float startTime2 = 10f;
    private float repeatRate2 = 10f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, repeatRate);
        InvokeRepeating("SpawnPowerUp", startTime2, repeatRate2);
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

    public void SpawnPowerUp()
    {
        int randomIndex = Random.Range(0, PowerUps.Length);
        Instantiate(PowerUps[randomIndex], RandomSpawnPosition(),
        PowerUps[randomIndex].transform.rotation);
    }

}

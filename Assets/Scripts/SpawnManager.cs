using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private float zRange = 18f;
    private float xRange = 32f;
    private float startTime = 1f;
    private float repeatRate = 3f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

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

}

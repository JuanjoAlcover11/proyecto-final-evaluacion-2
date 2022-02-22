using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private float zRange = 18f;
    private float xRange = 32f;
    private float startTime = 2f;
    private float repeatRate = 4f;

    private int enemiesPerWave = 1;
    private int enemiesLeft;
    void Start()
    {
       // SpawnEnemyWave(enemiesPerWave);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Array para los enemigos
    public GameObject[] Enemies;
    //Array para los coleccionables
    public GameObject[] Coins;
    //Rango en el que pueden aparcer
    private float zRange = 18f;
    private float xRange = 32f;
    //Tiempos de aparicion
    private float startTime = 1f;
    private float repeatRate = 3f;
    private float startTime2 = 5f;
    private float repeatRate2 = 5f;

    private GameManager gameManagerScript;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, repeatRate);
        InvokeRepeating("SpawnCoins", startTime2, repeatRate2);
        //Llamamos al script gameManager para utilizar sus variables
        gameManagerScript = FindObjectOfType<GameManager>();
    }
    public Vector3 RandomSpawnPosition()
    {
        //Establecemos una posicion aleatoria en X y Z
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);
        return new Vector3(randomX, 0, randomZ);
    }
    public void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, Enemies.Length);
        //Usamos un if para que solo funcione si no hay GameOver
        if (!gameManagerScript.gameOver)
        {
            //Hacemos aparecer a los enemigos
            Instantiate(Enemies[randomIndex], RandomSpawnPosition(),
        Enemies[randomIndex].transform.rotation);
        }
    }

    public void SpawnCoins()
    {
        int randomIndex = Random.Range(0, Coins.Length);
        //Usamos un if para que solo funcione si no hay GameOver
        if (!gameManagerScript.gameOver)
        {
            //Hacemos aparecer los coleccionables
            Instantiate(Coins[randomIndex], RandomSpawnPosition(),
        Coins[randomIndex].transform.rotation);
        }
    }
}

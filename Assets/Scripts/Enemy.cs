using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Rigid body de los enemigos
    private Rigidbody enemyRigidbody;
    //Nuestro jugador
    private GameObject player;
    //Velocidad de los enemigos, publica para cambiarla a nuestro gusto
    public float speed;
    //Script gameManager
    private GameManager gameManagerScript;

    void Start()
    {
        //Llamamos al rigid body de los enemigos
        enemyRigidbody = GetComponent<Rigidbody>();
        //LLamamos a nuestro jugador
        player = GameObject.Find("Player");
        //Llamamos al script gameManager para utilizar sus variables
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //Usamos un if para que solo funcione si no hay GameOver
        if (!gameManagerScript.gameOver)
        {
            //Hacemos que los enemigos avancen
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //Hacemos que los enemigos miren siempre al player
            transform.LookAt(player.transform.position);
        }
    }
}

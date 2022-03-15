using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    private GameObject player;
    public float speed = 6;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.LookAt(player.transform.position);
        }
    }
}

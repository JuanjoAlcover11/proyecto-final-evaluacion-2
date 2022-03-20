using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float rotateSpeed = 200f;
    public int points;
    private GameManager gameManagerScript;
    public ParticleSystem coinParticle;

    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            Instantiate(coinParticle, transform.position,
                coinParticle.transform.rotation);
            gameManagerScript.UpdateScore(points);
            Destroy(gameObject);
        }
    }
}

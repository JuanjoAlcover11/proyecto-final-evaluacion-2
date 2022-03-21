using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //Velocidad de rotacion
    private float rotateSpeed = 200f;
    //Puntos que vale cada coleccionable
    public int points;
    //Script gameManager
    private GameManager gameManagerScript;
    //Particulas de los coleccionables
    public ParticleSystem coinParticle;

    void Start()
    {
        //Llamamos al script gameManager para utilizar sus variables
        gameManagerScript = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        //Hacemos que roten constantemente
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        //Usamos un if para que solo funcione si no hay GameOver
        if (!gameManagerScript.gameOver)
        {
            //Si colisiona con el player...
            if (otherCollider.gameObject.CompareTag("Player"))
            {
                //Aparece la particula
                Instantiate(coinParticle, transform.position,
                    coinParticle.transform.rotation);
                //Sumamos los puntos
                gameManagerScript.UpdateScore(points);
                //Se destruye el coleccionable
                Destroy(gameObject);
            }
        }
    }
}

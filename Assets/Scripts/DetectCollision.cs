using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    //Script gameManager
    private GameManager gameManagerScript;
    //Variable int que representa los puntos de cada partida
    public int points;
    //Particulas explosion player
    public ParticleSystem explosionParticle;
    //Particulas explosion enemigo
    public ParticleSystem explosionParticle2;
    //Audio Source para poder usar musica/efectos
    private AudioSource Audio;
    //Efectos de sonido (explosiones)
    public AudioClip pumClip;
    public AudioClip boomClip;

    void Start()
    {
        //Llamamos al script gameManager para utilizar sus variables
        gameManagerScript = FindObjectOfType<GameManager>();
        //Llamamos al Audio Source
        Audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        //Al colisionar con un proyectil...
        if (otherCollider.gameObject.CompareTag("Proyectile"))
        {
            //Aparece la particula
            Instantiate(explosionParticle2, transform.position,
                explosionParticle2.transform.rotation);
            //Se reproduce el sonido
            Audio.PlayOneShot(pumClip, 1);
            //Se destruye el proyectil
            Destroy(otherCollider.gameObject);
            //Se destruye el enemigo
            Destroy(gameObject);
            //Sumamos al contador los respectivos puntos (dependiendo del tipo de enemigo)
            gameManagerScript.UpdateScore(points);
            
        }
        //Al colisionar con el player...
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            //Se reproduce el sonido
            Audio.PlayOneShot(boomClip, 1);
            //Se destruye el player
            Destroy(otherCollider.gameObject);
            //Llamamos a la funcion gameOver del script gameManager
            gameManagerScript.GameOver();
            //Aparece la particula
            Instantiate(explosionParticle, transform.position,
                explosionParticle.transform.rotation);
        }        
    }
}

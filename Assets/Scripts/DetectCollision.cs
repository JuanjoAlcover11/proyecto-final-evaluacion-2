using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManagerScript;
    public int points;
    public ParticleSystem explosionParticle;
    public ParticleSystem explosionParticle2;

    private AudioSource Audio;
    public AudioClip pumClip;
    public AudioClip boomClip;

    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
        Audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("Proyectile"))
        {
            Instantiate(explosionParticle2, transform.position,
                explosionParticle2.transform.rotation);
            Audio.PlayOneShot(pumClip, 1);

            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            gameManagerScript.UpdateScore(points);
            
        }
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            Audio.PlayOneShot(boomClip, 1);
            Destroy(otherCollider.gameObject);
            gameManagerScript.GameOver();
            Instantiate(explosionParticle, transform.position,
                explosionParticle.transform.rotation);
        }        
    }
}

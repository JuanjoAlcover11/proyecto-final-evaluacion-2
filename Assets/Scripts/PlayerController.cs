using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad a la que se desplaza nuestro jugador
    private float velocidad = 10f;
    //Velocidad a la que rota nuestro jugador
    private float turnSpeed = 150f;
    //Establecemos los limites de pantalla
    private float leftRange = -32f;
    private float rightRange = 32f;
    private float downRange = -18f;
    private float upRange = 17f;
    //Controles por flechas o WASD
    private float horizontalInput;
    private float verticalInput;
    //El proyectil que dispara nuestro jugador
    public GameObject projectilPrefab;
    //Posicion inicial de nuestro jugador
    private Vector3 offset = new Vector3(0, 0, 0);
    //Audio Source para poder usar musica/efectos
    private AudioSource Audio;
    //Efectos de sonido (disparo y coleccionable)
    public AudioClip coinClip;
    public AudioClip blastClip;

    void Start()
    {
        //Hacenmos que el player se mueva a la posicion inicial
        transform.position = offset;
        //Llamamos al Audio Source
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {  
        //Controlamos el avance del player con los controles verticales 
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime * verticalInput);
        //Controlamos la rotacion del player con los controles horizontales
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        //Al pulsar el espacio...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Aparece el proyectil
            Instantiate(projectilPrefab, transform.position,
           gameObject.transform.rotation);
            //Se reproduce el sonido de disparo
            Audio.PlayOneShot(blastClip, 1);

        }
        //Hacemos que si sobrepasamos los limites de pantalla no nos deje pasar
        if (transform.position.x < leftRange)
        {
            transform.position = new Vector3(leftRange, transform.position.y,
                transform.position.z);
        }

        if (transform.position.x > rightRange)
        {
            transform.position = new Vector3(rightRange, transform.position.y,
                transform.position.z);
        }

        if (transform.position.z < downRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                downRange);
        }

        if (transform.position.z > upRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                upRange);
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        //Se reproduce el sonido de coleccionable
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            Audio.PlayOneShot(coinClip, 1);
        }
    }
}
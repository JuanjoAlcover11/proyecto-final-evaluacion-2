using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocidad = 10f;
    private float turnSpeed = 150f;

    private float leftRange = -32f;
    private float rightRange = 32f;
    private float downRange = -18f;
    private float upRange = 17f;

    private float horizontalInput;
    private float verticalInput;

    public GameObject projectilPrefab;

    private Vector3 offset = new Vector3(0, 0, 0);

    private AudioSource Audio;
    public AudioClip coinClip;
    public AudioClip blastClip;

    void Start()
    {
        transform.position = offset;
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime * verticalInput);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilPrefab, transform.position,
           gameObject.transform.rotation);
            Audio.PlayOneShot(blastClip, 1);

        }

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
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            Audio.PlayOneShot(coinClip, 1);
        }
    }
}
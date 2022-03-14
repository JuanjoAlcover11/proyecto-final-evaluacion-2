using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocidad = 8f;
    private float turnSpeed = 100f;

    private float horizontalInput;
    private float verticalInput;

    public GameObject projectilPrefab;

    private Vector3 offset = new Vector3(0, 0, 0);

    private bool hasPowerUp;
    private float powerUpSpeed = 20f;
    private float powerUpTimer = 5f;
    public bool GameOver;
    void Start()
    {
        transform.position = offset;
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

        }
    }
    private IEnumerator PowerupCountDown()
    {
        for (int i = 0; i < powerUpTimer; i++)
        {
            yield return new WaitForSeconds(2);
            //velocidad = powerUpSpeed;
        }
        hasPowerUp = false;
    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerupCountDown());
            Destroy(otherCollider.gameObject);
        }
    }
}
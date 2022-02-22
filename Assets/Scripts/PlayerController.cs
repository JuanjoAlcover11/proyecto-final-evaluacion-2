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

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(projectilPrefab, transform.position,
           gameObject.transform.rotation);

        }
    }
}
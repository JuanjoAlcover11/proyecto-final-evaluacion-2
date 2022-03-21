using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //Velocidad del proyectil
    private float speedBala = 30f;

    void Update()
    {
        //Hacemos que el proyectil avance
        transform.Translate(Vector3.forward * speedBala * Time.deltaTime);
    }
}

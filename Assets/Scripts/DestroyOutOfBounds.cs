using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Limites en los que el proyectil se destruye
    private float zLim = 20f;
    private float xLim = 35f;
    
    void Update()
    {
            //Si el proyectil sale de pantalla, se destruye
            if (transform.position.z > zLim || transform.position.z < -zLim)
            {
                Destroy(gameObject);
            }
            if (transform.position.x > xLim || transform.position.x < -xLim)
            {
                Destroy(gameObject);
            }
    }
}

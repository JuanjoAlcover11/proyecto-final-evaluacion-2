using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zLim = 20f;
    private float xLim = 35f;
    // Update is called once per frame
    void Update()
    {

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

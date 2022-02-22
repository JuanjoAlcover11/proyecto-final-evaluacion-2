using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speedBala = 30f;

    void Update()
    {
        transform.Translate(Vector3.forward * speedBala * Time.deltaTime);
    }
}

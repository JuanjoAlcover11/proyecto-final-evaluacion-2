using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        Destroy(gameObject);

        Destroy(otherCollider.gameObject);
    }
}

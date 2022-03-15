using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private Enemy enemyScript;
    private void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("Proyectile"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
        }
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            Destroy(otherCollider.gameObject);
            enemyScript.gameOver = true;
        }        
    }
}

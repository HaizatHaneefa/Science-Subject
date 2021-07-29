using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("Enemy"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}

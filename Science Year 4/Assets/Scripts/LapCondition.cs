using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCondition : MonoBehaviour
{
    [SerializeField] myCarController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<myCarController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            controller.EndGame();
        }
    }
}

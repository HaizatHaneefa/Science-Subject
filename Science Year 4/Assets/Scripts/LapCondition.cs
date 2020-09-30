using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCondition : MonoBehaviour
{
    [SerializeField] CarController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CarController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            controller.EndGame();
        }
    }
}

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
        //if (other.CompareTag("Car"))
        //{
        //    if (controller.lap[0])
        //    {
        //        controller.lap[1] = true;
        //    }
        //    else if (controller.lap[1])
        //    {
        //        controller.lap[2] = true;
        //    }
        //    else if (controller.lap[2])
        //    {
        //        controller.EndGame();

        //        Debug.Log("baby dont lie lei leie");
        //    }
        //}
        if (other.CompareTag("Car"))
        {
            controller.EndGame();
        }
    }
}

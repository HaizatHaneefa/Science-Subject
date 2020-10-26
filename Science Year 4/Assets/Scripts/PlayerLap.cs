using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLap : MonoBehaviour
{
    [SerializeField] private GameObject[] lapConditions;
    [SerializeField] public int count;

    myCarController controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<myCarController>();

        count = 0;

        for (int i = 0; i < lapConditions.Length; i++)
        {
            lapConditions[i].GetComponent<BoxCollider>().enabled = false;
            lapConditions[0].GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Lap()
    {
        for (int i = 0; i < lapConditions.Length; i++)
        {
            lapConditions[i].GetComponent<BoxCollider>().enabled = false;
            lapConditions[count].GetComponent<BoxCollider>().enabled = true;
        }
    }

    void Update()
    {
        Lap();
    }
}

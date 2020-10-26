using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionData : MonoBehaviour
{
    public bool[] carSelection;

    //[SerializeField] private GameObject[] cars;
    //[SerializeField] private GameObject carSelected;

    private void Start()
    {
        carSelection = new bool[3];

        //if (carSelection[0])
        //{
        //    carSelected = Instantiate(cars[0], transform.position, Quaternion.identity);
        //    //cars[0].SetActive(true);
        //}
        //else if (carSelection[1])
        //{
        //    //cars[1].SetActive(true);
        //    carSelected = Instantiate(cars[1], transform.position, Quaternion.identity);
        //}
        //else if (carSelection[2])
        //{
        //    //cars[2].SetActive(true);
        //    carSelected = Instantiate(cars[2], transform.position, Quaternion.identity);
        //}
    }

    void Awake()
    {
        if (carSelection[0])
        {
            // car 1
        }
        else if (carSelection[1])
        {
            // car 2
        }
        else if (carSelection[2])
        {
            // car 3
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    }
}

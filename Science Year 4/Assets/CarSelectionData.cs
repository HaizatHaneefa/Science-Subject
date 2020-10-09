using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionData : MonoBehaviour
{
    public bool[] carSelection;

    private void Start()
    {
        carSelection = new bool[3];
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

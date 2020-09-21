using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAnimalRace : MonoBehaviour
{
    FiveAnimalGameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<FiveAnimalGameManager>();
    }

    void Update()
    {
        if (manager.isReady)
        {
            transform.position -= transform.right * 40f * Time.deltaTime;
        }
    }
}

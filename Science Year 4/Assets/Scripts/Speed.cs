using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    Y5PlantGame manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Y5PlantGame>();
    }

    void Update()
    {
        if (manager.isReady)
        {
            transform.position -= transform.right * 40f * Time.deltaTime;
        }
    }

}

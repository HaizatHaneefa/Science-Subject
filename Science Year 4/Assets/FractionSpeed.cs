using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractionSpeed : MonoBehaviour
{
    Y4FractionsGame manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Y4FractionsGame>();
    }

    void Update()
    {
        if (manager.isReady)
        {
            transform.position -= transform.right * 15f * Time.deltaTime;
        }
    }
}

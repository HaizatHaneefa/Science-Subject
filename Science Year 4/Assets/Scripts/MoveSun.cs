﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour
{
    [SerializeField] private GameObject plant;

    [SerializeField] float speedModifier;

    Y5C5PlantAR manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Y5C5PlantAR>();
     }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                double halfScreen = Screen.width / 2.0;

                //Check if it is left or right?
                if (touchPosition.x < halfScreen)
                {
                    transform.Translate(Vector3.left * speedModifier * Time.deltaTime);
                }
                else if (touchPosition.x > halfScreen)
                {
                    transform.Translate(Vector3.right * speedModifier * Time.deltaTime);
                }
            }
        }

        if (manager.isMoving)
        {
            Transform point = plant.transform;

            point.rotation = new Quaternion(0, 0, 0, 0);

            plant.transform.LookAt(gameObject.transform);
        }
    }
}
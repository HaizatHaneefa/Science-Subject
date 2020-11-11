﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    [SerializeField] private Transform playerBody;
    void Start()
    {
        
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
    }
}

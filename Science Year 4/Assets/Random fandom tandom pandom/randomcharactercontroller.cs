using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcharactercontroller : MonoBehaviour
{
    CharacterController charcontroller;
    float vertical, horizontal;

    void Start()
    {
        charcontroller = GetComponent<CharacterController>();   
    }

    void Movement()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");



    }
    void FixedUpdate()
    {
        Movement();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal, vertical;

    public VariableJoystick joystick;

    float speed;

    Rigidbody rb;

    void Start()
    {
        speed = 5f;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        Vector3 movement = new Vector3(horizontal, vertical, -vertical);

        rb.AddForce(movement * speed);


    }
}

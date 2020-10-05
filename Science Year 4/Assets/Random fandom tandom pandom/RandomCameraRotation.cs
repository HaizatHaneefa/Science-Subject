using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCameraRotation : MonoBehaviour
{
    [SerializeField] private Transform plane;

    [SerializeField] private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        //plane.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}

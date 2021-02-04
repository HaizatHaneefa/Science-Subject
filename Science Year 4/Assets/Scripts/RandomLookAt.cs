using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLookAt : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}

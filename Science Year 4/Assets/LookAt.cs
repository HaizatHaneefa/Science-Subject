using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject cam;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(cam.transform);
    }
}

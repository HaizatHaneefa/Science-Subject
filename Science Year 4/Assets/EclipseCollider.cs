using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EclipseCollider : MonoBehaviour
{
    [SerializeField] EclipseGameManager manager;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EclipseGameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        // pop a button
    }

    void Update()
    {
        
    }
}

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
        if (other.CompareTag("Player"))
        {
            manager.confirmButton.gameObject.SetActive(true);
        }
        // pop a button
    }

    private void OnTriggerExit(Collider other)
    {
        manager.confirmButton.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Confirm()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}

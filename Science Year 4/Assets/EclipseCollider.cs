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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Animal 1") && !manager.isDone[0])
            {
                // prompt the thingy
                manager.confirmButton.gameObject.SetActive(true);
            }
            else if (gameObject.CompareTag("Animal 2") && !manager.isDone[0])
            {
                // prompt the other thingy
                manager.wrongPop.SetActive(true);
            }
            else if (gameObject.CompareTag("Animal 3") && !manager.isDone[0])
            {
                manager.wrongPop.SetActive(true);
                // prompt the same other thingy
            }

            if (gameObject.CompareTag("Animal 2") && manager.isDone[0])
            {
                // prompt the thingy
                manager.confirmButton.gameObject.SetActive(true);
            }
            else if (gameObject.CompareTag("Animal 3") && manager.isDone[0] && !manager.isDone[1])
            {
                // prompt the other thingy
                manager.wrongPop.SetActive(true);
            }

            if (gameObject.CompareTag("Animal 3") && manager.isDone[1])
            {
                // prompt the thingy
                manager.confirmButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        manager.confirmButton.gameObject.SetActive(false);
        manager.wrongPop.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Confirm()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}

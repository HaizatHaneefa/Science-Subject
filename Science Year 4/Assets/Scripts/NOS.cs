using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOS : MonoBehaviour
{
    [SerializeField] myCarController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<myCarController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            
            StartCoroutine(SDSD());
        }
    }

    IEnumerator SDSD()
    {
        Debug.Log("wewqqq");

        if (gameObject.tag == "True")
        {
            controller.isBoost = true;

        }
        else if (gameObject.tag == "False")
        {
            controller.isReduce = true;
        }

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
}

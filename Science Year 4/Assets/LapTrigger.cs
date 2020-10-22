using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTrigger : MonoBehaviour
{
    PlayerLap lap;

    void Start()
    {
        lap = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerLap>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            StartCoroutine(CancelCollider());
        }
    }

    IEnumerator CancelCollider()
    {
        GetComponent<BoxCollider>().enabled = false;

        lap.count = lap.count + 1;

        if (lap.count == 13)
        {
            lap.count = 0;
        }

        yield return new WaitForSeconds(2f);

        GetComponent<BoxCollider>().enabled = true;
    }
}

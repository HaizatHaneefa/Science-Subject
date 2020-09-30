using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrackMarker : MonoBehaviour
{
    int markNumber;

    [SerializeField] GameObject[] markers;

    GameObject tracker;

    void Start()
    {
        markNumber = 0;

        tracker = gameObject;
    }

    void Update()
    {
        if (markNumber == 0)
        {
            transform.position = markers[0].transform.position;
        }
        else if (markNumber == 1)
        {
            transform.position = markers[1].transform.position;
        }
        else if (markNumber == 2)
        {
            transform.position = markers[2].transform.position;
        }
        else if (markNumber == 3)
        {
            transform.position = markers[3].transform.position;
        }
        else if (markNumber == 4)
        {
            transform.position = markers[4].transform.position;
        }
        else if (markNumber == 5)
        {
            transform.position = markers[5].transform.position;
        }
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        markNumber += 1;

        if (markNumber == 5)
        {
            markNumber = 0;
        }

        yield return new WaitForSeconds(1);

        GetComponent<BoxCollider>().enabled = true;
    }
}

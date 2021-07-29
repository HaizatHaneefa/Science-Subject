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
        else if (markNumber == 6)
        {
            transform.position = markers[6].transform.position;
        }
        else if (markNumber == 7)
        {
            transform.position = markers[7].transform.position;
        }
        else if (markNumber == 8)
        {
            transform.position = markers[8].transform.position;
        }
        else if (markNumber == 9)
        {
            transform.position = markers[9].transform.position;
        }
        else if (markNumber == 10)
        {
            transform.position = markers[10].transform.position;
        }
        else if (markNumber == 11)
        {
            transform.position = markers[11].transform.position;
        }
        else if (markNumber == 12)
        {
            transform.position = markers[12].transform.position;
        }
        else if (markNumber == 13)
        {
            transform.position = markers[13].transform.position;
        }
        else if (markNumber == 14)
        {
            transform.position = markers[14].transform.position;
        }
        else if (markNumber == 15)
        {
            transform.position = markers[15].transform.position;
        }
        else if (markNumber == 16)
        {
            transform.position = markers[16].transform.position;
        }
        else if (markNumber == 17)
        {
            transform.position = markers[17].transform.position;
        }
        else if (markNumber == 18)
        {
            transform.position = markers[18].transform.position;
        }
        else if (markNumber == 19)
        {
            transform.position = markers[19].transform.position;
        }
        else if (markNumber == 20)
        {
            transform.position = markers[20].transform.position;
        }
        else if (markNumber == 21)
        {
            transform.position = markers[21].transform.position;
        }
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        markNumber = markNumber + 1;

        if (markNumber == 21)
        {
            markNumber = 0;
        }

        yield return new WaitForSeconds(1f);

        GetComponent<BoxCollider>().enabled = true;
    }
}

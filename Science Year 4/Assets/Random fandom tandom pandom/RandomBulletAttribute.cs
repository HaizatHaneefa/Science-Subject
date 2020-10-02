using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletAttribute : MonoBehaviour
{
    RandomShootPlayer manager;

    void Start()
    {
        //manager = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomShootPlayer>();

        Destroy(gameObject, 5f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 conPoint = contact.point;

            //GameObject bulletBreakPrefab = Instantiate(manager.bulletBreak, conPoint, Quaternion.identity);
            //bulletBreakPrefab.transform.GetChild(0).gameObject.SetActive(true);

            //GameObject planeGO = GameObject.FindGameObjectWithTag("Plane");
            //bulletBreakPrefab.transform.SetParent(planeGO.transform);

            Destroy(gameObject);
        }
    }
}

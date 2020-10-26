using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCannon : MonoBehaviour
{
    [SerializeField] GameObject body, cannon, bullet;
    [SerializeField] Transform spawnPoint;

    [SerializeField] Camera mainCam;
    float speed;

    void Start()
    {
        speed = 10f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bulletPrefab = Instantiate(bullet, spawnPoint.position, Quaternion.identity);

            bulletPrefab.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 1000f);
            // bulelt fire
            // set bullet rate
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // enable rotation for the cannon, left or right
           body.transform.Rotate(0, -10f * speed * Time.deltaTime, 0, Space.World);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // enable rotation for the cannon, left or right
            body.transform.Rotate(0, 10f * speed * Time.deltaTime, 0, Space.World);
        }
    }
}

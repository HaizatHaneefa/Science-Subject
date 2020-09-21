using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShootPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bulletSpeed;
    Rigidbody rb;

    [SerializeField] private Camera cam;

    Vector3 targetPosition;

    [SerializeField] private GameObject bullet;
    [SerializeField] public GameObject bulletBreak;

    [SerializeField] private GameObject dummy;
    [SerializeField] private Transform spawner;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(targetPosition);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= transform.forward * speed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += transform.right * speed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= transform.right * speed * Time.deltaTime;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletPrefab = Instantiate(bullet, spawner.position, Quaternion.identity);

            bulletPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        }
    }
}

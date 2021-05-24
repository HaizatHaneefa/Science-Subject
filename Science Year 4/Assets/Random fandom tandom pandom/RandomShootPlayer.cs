using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RandomShootPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float speed;
    [SerializeField] private float bulletSpeed;
    Rigidbody rb;

    [SerializeField] private Camera cam;

    Vector3 targetPosition;

    [SerializeField] private GameObject bullet;
    [SerializeField] public GameObject bulletBreak;

    [SerializeField] private GameObject dummy;
    [SerializeField] private Transform spawner;

    CharacterController charController;

    bool canFire, cooldownHealth;
    float timer, health;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        charController = GetComponent<CharacterController>();

        canFire = true;

        health = 100f;
    }

    void Update()
    {
        healthText.text = "Health: " + health.ToString();

        float moveForward = Input.GetAxis("Vertical");

        if (!canFire) // setting a fire rate
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                canFire = true;
                timer = 0f;
            }
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // get mouse location in screen
        {
            targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(targetPosition);
        }

        if (Input.GetKey(KeyCode.W)) // if W key is pressed
        {
            //Vector3 moveent = new Vector3(0, 0, moveForward);
            //rb.AddForce(moveent * speed);

            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0)) // if left mouse click is clicked
        {
            if (canFire)
            {
                GameObject bulletPrefab = Instantiate(bullet, spawner.position, Quaternion.identity);

                bulletPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                canFire = false;
            }
            else if (!canFire)
            {
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Up") && !cooldownHealth)
        {
            Debug.Log("jfjfjf");
            health -= 10;
            cooldownHealth = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cooldownHealth = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    Y5PlantGame manager;

    [SerializeField] private float smooth;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Y5PlantGame>();
    }

    void Update()
    {
        if (manager.isPlaying && gameObject.transform.parent.CompareTag("Enemy"))
        {
            if (manager.newSpeed <= 45)
            {
                transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            }
            else if (manager.newSpeed <= 60 && manager.newSpeed >= 46)
            {
                transform.Rotate(Vector3.back * 120 * Time.deltaTime);
            }
            else if (manager.newSpeed <= 75 && manager.newSpeed >= 61)
            {
                transform.Rotate(Vector3.back * 140 * Time.deltaTime);
            }
            else if (manager.newSpeed <= 85 && manager.newSpeed >= 76)
            {
                transform.Rotate(Vector3.back * 160 * Time.deltaTime);
            }
            else if (manager.newSpeed <= 95 && manager.newSpeed >= 86)
            {
                transform.Rotate(Vector3.back * 180 * Time.deltaTime);
            }
            else if (manager.newSpeed <= 100 && manager.newSpeed >= 96)
            {
                transform.Rotate(Vector3.back * 200 * Time.deltaTime);
            }
        }
        else if (manager.isPlaying && gameObject.transform.parent.CompareTag("Player"))
        {
            if (manager.tstbool[0])
            {
                transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            }
            else if (manager.tstbool[1])
            {
                transform.Rotate(Vector3.back * 120 * Time.deltaTime);
            }
            else if (manager.tstbool[2])
            {
                transform.Rotate(Vector3.back * 140 * Time.deltaTime);
            }
            else if (manager.tstbool[3])
            {
                transform.Rotate(Vector3.back * 160 * Time.deltaTime);
            }
            else if (manager.tstbool[4])
            {
                transform.Rotate(Vector3.back * 180 * Time.deltaTime);
            }
            else if (manager.tstbool[5])
            {
                transform.Rotate(Vector3.back * 200 * Time.deltaTime);
            }
        }
    }
}

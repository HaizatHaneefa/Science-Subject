using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour
{
    [SerializeField] private GameObject plant, sun;

    [SerializeField] float speedModifier;

    Y5C5PlantAR manager;
    bool left, right;

    float xSun;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Y5C5PlantAR>();
     }

    void Update()
    {
        if (right)
        {
            if (sun.transform.position.x > 50f)
            {
                sun.transform.position = new Vector3(50f, sun.transform.position.y, sun.transform.position.z);
            }

            sun.transform.Translate(Vector3.right * speedModifier * Time.deltaTime);
        }
        else if (left)
        {
            if (sun.transform.position.x < -45f)
            {
                sun.transform.position = new Vector3(-45f, sun.transform.position.y, sun.transform.position.z);

            }

            sun.transform.Translate(Vector3.left * speedModifier * Time.deltaTime);
        }

        //if (Input.touchCount > 0)
        //{
        //    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        //    {
        //        Vector2 touchPosition = Input.GetTouch(0).position;
        //        double halfScreen = Screen.width / 2.0;

        //        //Check if it is left or right?
        //        if (touchPosition.x < halfScreen)
        //        {
        //            transform.Translate(Vector3.left * speedModifier * Time.deltaTime);
        //        }
        //        else if (touchPosition.x > halfScreen)
        //        {
        //            transform.Translate(Vector3.right * speedModifier * Time.deltaTime);
        //        }
        //    }
        //}

        if (manager.isMoving)
        {
            Transform point = plant.transform;

            point.rotation = new Quaternion(0, 0, 0, 0);

            plant.transform.LookAt(gameObject.transform);
        }
    }

    public void RightSide()
    {
        right = true;
    }

    public void ReleaseRight()
    {
        right = false;
    }

    public void LeftSide()
    {
        left = true;
    }

    public void ReleaseLeft()
    {
        left = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed, floatSpeed, floatheight;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.Self);

        float y = Mathf.PingPong(Time.time * floatSpeed, floatheight);
        transform.position = new Vector3(transform.position.x, 0.579f + y, transform.position.z);
    }


    //public int hight = 1;//max height of Box's movement
    //public float yCenter = 0f;

    //void Update()
    //{
    //    transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * 2, hight) - hight / 2f, transform.position.z);//move on y axis only
    //                                                                                                                                              //Box is moving with Mathf.PingPong (http://docs.unity3d.com/Documentation/ScriptReference/Mathf.PingPong.html)
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed, floatSpeed, floatheight;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.Self);

        float y = Mathf.PingPong(Time.time * floatSpeed, floatheight);
        transform.position = new Vector3(transform.position.x, 0.579f + y, transform.position.z);

    }

}

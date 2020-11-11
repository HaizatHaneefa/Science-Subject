using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EclipseLookAt : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targetPostition = new Vector3(target.position.x,
                                       this.transform.position.y,
                                       target.position.z);

        this.transform.LookAt(targetPostition);
    }
}

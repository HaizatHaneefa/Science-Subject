using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCarMovementMinimap : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    private float xOffset;
    private float yOffset;
    private float zOffset;


    void Start()
    {
        xOffset = transform.position.x - targetTransform.position.x;
        yOffset = transform.position.y - targetTransform.position.y;
        zOffset = transform.position.z - targetTransform.position.z;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(targetTransform.position.x + xOffset,
           targetTransform.position.y + yOffset,
           targetTransform.position.z + zOffset); 
    }
}

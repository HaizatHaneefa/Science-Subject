using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;

    float minRotation, maxRotation;

    void Start()
    {
        minRotation = -45f;
        maxRotation = 45f;

        _sensitivity = 1f;
        _rotation = Vector3.zero;
    }

    void Update()
    {
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            //_rotation.y = -(_mouseOffset.x) * _sensitivity;
            //_rotation.x = (_mouseOffset.y) * _sensitivity;

            // rotate
            transform.Rotate(_rotation, Space.Self);
            //_rotation.x = Mathf.Clamp(transform.eulerAngles.y, minRotation, maxRotation);

            // store mouse
            _mouseReference = Input.mousePosition;
        }

        //if (transform.rotation.eulerAngles.y > maxRotation)
        //{
        //    Vector3 v = transform.rotation.eulerAngles;
        //    transform.rotation = Quaternion.Euler(v.x, maxRotation, v.z);
        //}
        //else if (transform.rotation.eulerAngles.y < minRotation)
        //{
        //    Vector3 v = transform.rotation.eulerAngles;
        //    transform.rotation = Quaternion.Euler(v.x, minRotation, v.z);
        //}
    }

   public void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;

      
    }

    public void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }
}

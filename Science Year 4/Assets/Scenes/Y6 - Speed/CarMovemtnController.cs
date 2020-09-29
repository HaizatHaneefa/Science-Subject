using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CarMovemtnController : MonoBehaviour
{
    [SerializeField] private CarController controller;

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private float m_brake;

    public WheelCollider rightFrontW, leftFrontW;
    public WheelCollider rightBackW, leftBackW;

    public Transform rightFrontT, leftFrontT;
    public Transform rightBackT, leftBackT;

    public float maxSteerAngle;
    public float motorForce;
    private float brakeForce;

    [SerializeField] Vector3 something;
    public Button throttleButton;

    [SerializeField] bool isPressing;
    [SerializeField] private bool isBraking;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CarController>();

        gameObject.GetComponent<Rigidbody>().centerOfMass += something;
    }
    public void GetInput()
    {
        m_horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        m_verticalInput = CrossPlatformInputManager.GetAxisRaw("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;

        rightFrontW.steerAngle = m_steeringAngle;
        leftFrontW.steerAngle = m_steeringAngle;
    }

    public void Accelerate()
    {
        if (!controller.isBoost)
        {
            rightFrontW.motorTorque = m_verticalInput * motorForce; // joystick or button
            leftFrontW.motorTorque = m_verticalInput * motorForce;
        }
        else if (controller.isBoost)
        {
            rightFrontW.motorTorque = m_verticalInput * motorForce * controller._nosBoost; // joystick or button
            leftFrontW.motorTorque = m_verticalInput * motorForce * controller._nosBoost;
        }
    }

    public void Brake()
    {
        if (isPressing)
        {
            brakeForce = 0f;
        }
        else if (!isPressing)
        {
            brakeForce = 100f;
        }

        if (isBraking)
        {
            brakeForce = 2000f;
        }

        rightFrontW.brakeTorque = brakeForce;
        leftFrontW.brakeTorque = brakeForce;

        Debug.Log(brakeForce);
    }

    public void Braking()
    {
        isBraking = true;
    }

    public void NotBraking()
    {
        isBraking = false;
    }

    private void UpdateWheelPos(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void UpdateWHeelPoses()
    {
        UpdateWheelPos(rightFrontW, rightFrontT);
        UpdateWheelPos(leftFrontW, leftFrontT);
        UpdateWheelPos(rightBackW, rightBackT);
        UpdateWheelPos(leftBackW, leftBackT);
    }

    //public void ssss()
    //{
    //    if (!isPressing)
    //    {
    //        isPressing = true;
    //    }
    //    else if (isPressing)
    //    {
    //        isPressing = false;
    //    }
    //}

    public void OnPointerDown()
    {
        isPressing = true;
    }

    public void OnPointerUp()
    {
        isPressing = false;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        UpdateWHeelPoses();
        Accelerate();
        Brake();
    }
}

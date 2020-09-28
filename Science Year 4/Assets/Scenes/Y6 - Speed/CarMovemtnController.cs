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
    public float brakeForce;

    [SerializeField] Vector3 something;
    public Button throttleButton;

    [SerializeField] bool isPressing;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<CarController>();
        gameObject.GetComponent<Rigidbody>().centerOfMass += something;
    }
    public void GetInput()
    {
        m_horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        m_verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
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

    private void Brake()
    {
        rightFrontW.brakeTorque = brakeForce;
        leftFrontW.brakeTorque = brakeForce;
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

    public void ssss()
    {
        Debug.Log("wwww");

        if (!isPressing)
        {
            isPressing = true;
        }
        else if (isPressing)
        {
            isPressing = false;
        }
        //m_verticalInput += 0.1f;
    }
    private void FixedUpdate()
    {
        //ReduceSpeed();
        GetInput();
        Steer();
        UpdateWHeelPoses();
        Accelerate();
        Brake();

        if (isPressing)
        {
            if (m_verticalInput == 1)
            {
                return;
            }
            m_verticalInput += Time.deltaTime;
        }
        else if (!isPressing)
        {
            if (m_verticalInput == 0)
            {
                return;
            }
            m_verticalInput -= Time.deltaTime;
        }
    }
}

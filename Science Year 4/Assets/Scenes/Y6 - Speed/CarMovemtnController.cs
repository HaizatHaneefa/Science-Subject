using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovemtnController : MonoBehaviour
{
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

    bool isBreaking;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;

        rightFrontW.steerAngle = m_steeringAngle;
        leftFrontW.steerAngle = m_steeringAngle;
    }

    public void Accelerate()
    {
        rightFrontW.motorTorque = 1f * motorForce; // joystick or button
        leftFrontW.motorTorque = 1f * motorForce;
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

    private void FixedUpdate()
    {
        //brakeForce = 0f;
        GetInput();
        Steer();
        UpdateWHeelPoses();
        Accelerate();
        Brake();

      
    }
}

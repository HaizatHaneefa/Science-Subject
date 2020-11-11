using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CustomPlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public VariableJoystick joystick;

    [SerializeField] Transform cam;

    public float speed;
    [SerializeField] float sensitivity;
    float headRotation = 0f;
    [SerializeField] float headRotationLimit = 90f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 moveBy = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

        float mX = CrossPlatformInputManager.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mY = CrossPlatformInputManager.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;

        transform.Rotate(0f, mX, 0f);

        headRotation += mY;
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);

        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
    }
}
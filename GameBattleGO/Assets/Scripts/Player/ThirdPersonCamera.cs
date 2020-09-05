using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public VirtualJoystick virtualJoystick;
    public Transform lookAt;

    private Camera cam;
    public Transform camTransform { set; get; }

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 10.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 180.0f;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }
    private void Update()
    {
        currentX -= virtualJoystick.Horizontal() * sensitivityX;
        currentY += virtualJoystick.Vertical() * sensitivityY;

        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        do
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
        }
        while (angle < -360 && angle > 360);
        return Mathf.Clamp(angle, min, max);
    }
}
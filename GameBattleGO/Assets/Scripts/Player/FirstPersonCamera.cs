using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Camera fpsCamera;
    public VirtualJoystick virtualJoystick;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 2.1f;
    private float sensitivityY = 2.1f;

    void Update()
    {
        //control with mouse
        //      currentX = Input.GetAxis("Mouse X") * sensitivityX;
        //     currentY = Input.GetAxis("Mouse Y") * sensitivityY;
        //control with virtual joystick
    //    if (fpsCamera.isActiveAndEnabled)
    //    {
            currentX = virtualJoystick.Horizontal() * sensitivityX;
            currentY = virtualJoystick.Vertical() * sensitivityY;

            transform.Rotate(0, currentX, 0);
            fpsCamera.transform.Rotate(-currentY, 0, 0);
      //  }
    }
}

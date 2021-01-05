using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class spin : MonoBehaviour
{
    public Joystick joystick;
    // Update is called once per frame
    void Update()
    {
        float horizontal = -joystick.Horizontal;
        float vertical = joystick.Vertical;
        float rotationZ = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;

    public int runSpeed;

    public bool IsMoving
    {
        get
        {
            if (joystick.Horizontal == 0 && joystick.Vertical == 0)
                return false;
            return true;
        }
    }

    void Update()
    {
        Vector3 direction = new Vector3(-joystick.Vertical, 0f, joystick.Horizontal).normalized;

        transform.Translate(direction * runSpeed * Time.deltaTime);

        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            float targetAngle = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg;
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
    }
}

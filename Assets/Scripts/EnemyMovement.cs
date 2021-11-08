using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Joystick joystick;

    public float runSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;

        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(joystick.Vertical, 0f, -joystick.Horizontal);

        transform.Translate(direction * runSpeed * Time.deltaTime);
    }
}

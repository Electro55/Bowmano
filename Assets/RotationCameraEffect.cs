using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCameraEffect : MonoBehaviour
{
    public float rotSpeed;
    public Vector2 minMaxYRot;
    private float currentYRot;

    bool adding = false;

    void Start()
    {
        if(minMaxYRot.x > minMaxYRot.y)
        {
            float temp = minMaxYRot.y;
            minMaxYRot.y = minMaxYRot.x;
            minMaxYRot.x = temp;
        }

        currentYRot = transform.rotation.eulerAngles.y;
        currentYRot -= 360;

    }

    void Update()
    {
        if(adding)
        {
            currentYRot += rotSpeed * Time.deltaTime;
            if (currentYRot > minMaxYRot.y)
                adding = false;
        } else
        {
            currentYRot -= rotSpeed * Time.deltaTime;
            if (currentYRot < minMaxYRot.x)
                adding = true;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentYRot, transform.rotation.eulerAngles.z);

    }
}

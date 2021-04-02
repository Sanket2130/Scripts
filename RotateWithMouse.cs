using System;
using UnityEngine;


public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 3f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * turnSpeed * Vector3.up, Space.World);
    }
}
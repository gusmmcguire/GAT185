using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCamera : MonoBehaviour
{

    [SerializeField] Transform lookAt;
    [SerializeField] float distance = 5;
    [SerializeField] float pitch = 45;
    [SerializeField] float sensitivity = 1;

    private float yaw = 0;

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;
        Vector3 offset = rotation * Vector3.back * distance;

        transform.position = lookAt.position + offset;
        transform.rotation = Quaternion.LookRotation(-offset);
    }
}
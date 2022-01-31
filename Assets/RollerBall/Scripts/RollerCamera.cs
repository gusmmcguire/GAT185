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
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        //Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Vector3 offset = qpitch * Vector3.back * distance;

        transform.position = lookAt.position + offset;
    }
}
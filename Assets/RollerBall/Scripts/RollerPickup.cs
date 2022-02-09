using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerPickup : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float ampRate;
    [SerializeField] float spinRate;

    Vector3 initialPosition;
    float time;
    float angle;
    void Start()
    {
        time = Random.Range(0f, 5f);
        angle = Random.Range(0f, 360f);
        initialPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime * ampRate;
        angle += Time.deltaTime * spinRate;

        //up down
        Vector3 offset = Vector3.up * (Mathf.Sin(time) * amplitude);
        transform.position = initialPosition + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}

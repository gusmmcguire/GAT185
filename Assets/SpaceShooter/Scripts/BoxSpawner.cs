using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPrefabs;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    BoxCollider boxCollider;
    float timer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = Random.Range(minTime, maxTime);

            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)],GetRandomPointInBoxCollider(),transform.rotation);
        }
    }

    Vector3 GetRandomPointInBoxCollider()
    {
        Vector3 point = Vector3.zero;

        Vector3 min = boxCollider.bounds.min;
        Vector3 max = boxCollider.bounds.max;

        point.x = Random.Range(min.x, max.x);
        point.y = Random.Range(min.y, max.y);
        point.z = Random.Range(min.z, max.z);

        return point;
    }
}

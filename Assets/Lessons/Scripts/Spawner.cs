using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;

    private void Start()
    {
        //Destroy(gameObject, 6);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(spawnObject, transform.position, Quaternion.identity);
            Destroy(go, 4);
        }
    }
}

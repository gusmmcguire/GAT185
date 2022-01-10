using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10), SerializeField, Tooltip("Speed of the player")] float speed = 5;
    [SerializeField, Tooltip("Place the player's audio source here")] AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal"); 
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * speed * Time.deltaTime;
        //transform.rotation *= Quaternion.Euler(5,0,0);
        //transform.localScale += new Vector3(2, 2, 2) * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            //transform.rotation *= Quaternion.Euler(5, 0, 0);
            audioSource.Play();
            GetComponent<Renderer>().material.color = Color.black;
        }

        GameObject go = GameObject.Find("Cube");
        if(go)
        {
            go.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
}

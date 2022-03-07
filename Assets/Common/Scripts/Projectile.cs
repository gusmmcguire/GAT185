using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ForceMode forceMode;
    [SerializeField] float timer;
    [SerializeField] GameObject destoryPrefab;

    public void Start()
	{
        rb.AddRelativeForce(Vector3.forward * speed, forceMode);
        if (timer != 0) StartCoroutine(DestroyTime());
	}

    
    IEnumerator DestroyTime()
    {
        
        yield return new WaitForSeconds(timer);
        if (destoryPrefab != null) Instantiate(destoryPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (timer != 0) return;
        if(destoryPrefab != null) Instantiate(destoryPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

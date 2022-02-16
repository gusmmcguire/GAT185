using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RollerDoor : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
        }
    }
}

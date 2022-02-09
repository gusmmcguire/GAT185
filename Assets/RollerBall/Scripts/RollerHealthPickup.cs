using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerHealthPickup : RollerPickup, IDestructable
{
    [SerializeField] int providedHealth;
    public void Destroyed()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        p.GetComponent<Health>().health += providedHealth;
    }
}

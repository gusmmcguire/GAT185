using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolllerTimeIncrease : MonoBehaviour, IDestructable
{
    [SerializeField] float timeToAdd;

    public void Destroyed()
    {
        RollerGameManager.Instance.GameTime += timeToAdd;
    }
}

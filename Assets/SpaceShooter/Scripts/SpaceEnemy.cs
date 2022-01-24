using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemy : MonoBehaviour, IDestructable
{
    [SerializeField] SpaceWeapon spaceWeapon;
    [SerializeField] float minFireTime;
    [SerializeField] float maxFireTime;

    public int points;
    float timer;

    private void Start()
    {
        timer = Random.Range(minFireTime, maxFireTime);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = Random.Range(minFireTime, maxFireTime);
            if(spaceWeapon) spaceWeapon.Fire();
        }
    }

    public void Destroyed()
    {

        GameManager.Instance.Score += points;
    }
}

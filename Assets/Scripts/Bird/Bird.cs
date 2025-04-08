using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : Hitable
{
    [SerializeField] BirdShooter _shooter;
    
    private void Start()
    {
        _shooter.Init(Team);
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
        //Там гейм овер
    }
}
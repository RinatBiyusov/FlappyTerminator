using UnityEngine;
using System;

public class BirdShooter : Shooter
{
    [SerializeField] private BirdInput _input;

    public event Action<Transform, GroupTeam, Vector3> Shooted;

    private void OnEnable()
    {
        _input.ButtonClicked += Shoot;
    }

    private void OnDisable()
    {
        _input.ButtonClicked -= Shoot;
    }

    protected override void Shoot()
    {
        if (Time.timeScale > 0)
            Shooted?.Invoke(transform, Team, ShootPosition.position);
    }
}
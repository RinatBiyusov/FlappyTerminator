using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Hitable, IPoolableObject
{
    [SerializeField] private EnemyShooter _shooter;

    public event Action<Enemy> Disabled;

    public EnemyShooter Shooter => _shooter;

    protected override void OnDisable()
    {
        base.OnDisable();
        Disabled?.Invoke(this);
    }

    private void Start()
    {
        _shooter.Init(Team);
    }

    protected override void Die()
    {
        Disabled?.Invoke(this);
    }
}
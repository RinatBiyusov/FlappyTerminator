using System;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

public class Enemy : Hitable, IPoolableObject, ITouchable
{
    [SerializeField] private EnemyShooter _shooter;

    public event Action<Enemy> Disabled;

    public EnemyShooter Shooter => _shooter;

    protected override void OnDisable()
    {
        base.OnDisable();
        Disabled?.Invoke(this);
    }

    private void Start() =>
        _shooter.Init(Team);

    protected override void Die()
    {
        GameEvents.OnEnemyDied();
        Disabled?.Invoke(this);
    }
}
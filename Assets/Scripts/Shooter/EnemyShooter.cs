using System;
using UnityEngine;
using System.Collections;

public class EnemyShooter : Shooter
{
    [SerializeField] private float _shootRepeatTime = 3;

    private Coroutine _coroutine;
    private WaitForSeconds _reload;

    public event Action<Transform, GroupTeam, Vector3> Shooted;

    private void OnEnable()
    {
        Shoot();
    }

    private void OnDisable()
    {
        if (_coroutine == null)
            return;
        StopCoroutine(_coroutine);
    }

    private void Start()
    {
        _reload = new WaitForSeconds(_shootRepeatTime);
    }

    protected override void Shoot() =>
        _coroutine = StartCoroutine(Fire());

    private IEnumerator Fire()
    {
        while (enabled)
        {
            Shooted?.Invoke(transform, Team, ShootPosition.position);

            yield return _reload;
        }
    }
}
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : GenericSpawner<Enemy>
{
    [SerializeField] private EnemyDespawner _despawner;
    [SerializeField] private float _repeatWaitTime;
    [SerializeField] private float _maxPositionSpawnY;
    [SerializeField] private float _minPositionSpawnY;
    [SerializeField] private float _positionSpawnX;

    private WaitForSeconds _wait;

    public event Action<Enemy> Spawned;

    private void OnEnable()
    {
        _despawner.TriggeredToPool += Release;
    }

    private void OnDisable()
    {
        _despawner.TriggeredToPool -= Release;
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_repeatWaitTime);
        StartCoroutine(Spawn());
    }

    protected override void ActionOnGet(Enemy enemy)
    {
        enemy.transform.position = SetRandomSpawnPoint();
    }

    protected override void Release(Enemy enemy)
    {
        enemy.Disabled -= Release;
        base.Release(enemy);
    }

    private Vector3 SetRandomSpawnPoint()
    {
        float randomPositionY = Random.Range(_minPositionSpawnY, _maxPositionSpawnY);

        return new Vector3(_positionSpawnX, randomPositionY, 0);
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            if (Time.timeScale > 0)
            {
                Enemy enemy = TakeObject();
                enemy.Disabled += Release;
                Spawned?.Invoke(enemy);
                
                yield return _wait;
            }
            
            yield return null;
        }
    }
}
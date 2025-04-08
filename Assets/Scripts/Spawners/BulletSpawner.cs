using UnityEngine;

public class BulletSpawner : GenericSpawner<Bullet>
{
    [SerializeField] private BirdShooter _birdShooter;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletReceiver[] _bulletReceivers;

    private void OnEnable()
    {
        _birdShooter.Shooted += CreateBullet;
        _enemySpawner.Spawned += SubscribeWeapon;

        foreach (var receiver in _bulletReceivers)
            receiver.TriggeredToPool += Release;
    }

    private void OnDisable()
    {
        _birdShooter.Shooted -= CreateBullet;
        _enemySpawner.Spawned -= SubscribeWeapon;

        foreach (var receiver in _bulletReceivers)
            receiver.TriggeredToPool -= Release;
    }

    protected override void Release(Bullet bullet)
    {
        bullet.Hited -= Release;
        base.Release(bullet);
    }

    private void SubscribeWeapon(Enemy enemy)
    {
        enemy.Shooter.Shooted += CreateBullet;
        enemy.Disabled += UnsubscribeWeapon;
    }

    private void UnsubscribeWeapon(Enemy enemy)
    {
        enemy.Shooter.Shooted -= CreateBullet;
        enemy.Disabled -= UnsubscribeWeapon;
    }

    private void CreateBullet(Transform transformGun, GroupTeam team, Vector3 position)
    {
        Bullet bullet = TakeObject();
        bullet.Hited += Release;
        bullet.transform.position = position;
        bullet.SetDirection(CalculateDirection(transformGun));
        bullet.SetTeam(team);
    }

    private Vector2 CalculateDirection(Transform transformGun)
    {
        float angleDeg = transformGun.eulerAngles.z;
        float angleRad = angleDeg * Mathf.Deg2Rad;

        float xDir = transformGun.lossyScale.x >= 0 ? 1f : -1f;

        return new Vector2(Mathf.Cos(angleRad) * xDir, Mathf.Sin(angleRad));
    }
}
using System;

public static class GameEvents
{
    public static event Action EnemyDied;

    public static void OnEnemyDied() =>
        EnemyDied?.Invoke();
}
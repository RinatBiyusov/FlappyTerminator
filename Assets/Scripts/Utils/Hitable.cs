using UnityEngine;

public class Hitable : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GroupTeam _team;

    public GroupTeam Team => _team;
    public Health Health => _health;

    private void OnEnable()
    {
        _health.Died += Die;
    }

    protected virtual void OnDisable()
    {
        _health.Died -= Die;
    }

    protected virtual void Die()
    {
        _health.TakeDamage();
    }
}
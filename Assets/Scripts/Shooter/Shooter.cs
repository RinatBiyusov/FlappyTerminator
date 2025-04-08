using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;

    protected GroupTeam Team;
    
    protected Transform ShootPosition => _shootPosition;
    
    public void Init(GroupTeam team) =>
        Team = team;
    
    protected abstract void Shoot();
}
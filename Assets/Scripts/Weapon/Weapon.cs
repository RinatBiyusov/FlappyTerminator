using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    
    protected Transform ShootPosition { get; private set; }
    
    private void Awake() =>
        ShootPosition = _shootPoint;
}
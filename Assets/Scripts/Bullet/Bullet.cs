using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private GroupTeam _groupTeam;

    public event Action<Bullet> Hited;
    
    private void Update()
    {
        float movementSpeed = _speed * Time.deltaTime;

        transform.position += (Vector3)(_direction * movementSpeed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hitable hitable))
        {
            if (CheckTeam(hitable.Team) == false)
            {
                hitable.Health.TakeDamage();
                Hited?.Invoke(this);
            }
        }
    }

    private bool CheckTeam(GroupTeam groupTeam) =>
        groupTeam == _groupTeam;

    public void SetDirection(Vector2 dir) =>
        _direction = dir.normalized;

    public void SetTeam(GroupTeam groupTeam) =>
        _groupTeam = groupTeam;
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private  Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() =>
        _direction = Vector2.left;

    private void Update() =>
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime * _direction.x, transform.position.y);
}
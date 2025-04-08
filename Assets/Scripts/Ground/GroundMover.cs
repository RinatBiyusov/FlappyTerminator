using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private readonly Vector2 _direction = Vector2.left;

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + (_speed * _direction.x * Time.deltaTime), transform.position.y);
    }
}
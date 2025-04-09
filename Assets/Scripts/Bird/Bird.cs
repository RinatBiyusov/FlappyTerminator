using System;
using UnityEngine;
using Utils;

[RequireComponent(typeof(Rigidbody2D), typeof(ScoreCounter))]
public class Bird : Hitable
{
    [SerializeField] BirdShooter _shooter;

    private ScoreCounter _score;
    private Vector3 _startPosition;

    public event Action Died;

    private void Awake()
    {
        _score = GetComponent<ScoreCounter>();
    }

    private void Start()
    {
        _shooter.Init(Team);
        _startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITouchable touchable))
            Die();
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
        Died?.Invoke();
    }

    public void Reset()
    {
        _score.Reset();
        transform.position = _startPosition;
        gameObject.SetActive(true);
        transform.rotation = Quaternion.identity;
    }
}
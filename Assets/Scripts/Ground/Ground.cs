using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(GroundMover), typeof(Rigidbody2D))]
public class Ground : MonoBehaviour, IPoolableObject, ITouchable
{
    private Collider2D _collider;

    public event Action<Ground> LeftFromView;

    private void OnBecameInvisible() =>
        LeftFromView?.Invoke(this);
}
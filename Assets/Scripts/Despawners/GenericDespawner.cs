using UnityEngine;
using System;

    public class GenericDespawner<T> : MonoBehaviour  where T : IPoolableObject
    {
        public event Action<T> TriggeredToPool;
    
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out T t))
                TriggeredToPool?.Invoke(t);
        }
    }

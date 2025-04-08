using UnityEngine;
using System;

public class GroundDespawner : MonoBehaviour
{
    public  event Action<Ground> TriggeredToPool;
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (gameObject.activeInHierarchy == false)
            return;

        if (collider.TryGetComponent(out Ground ground))
            TriggeredToPool?.Invoke(ground);
    }
}
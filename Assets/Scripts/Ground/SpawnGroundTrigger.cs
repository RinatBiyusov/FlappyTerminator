using System;
using UnityEngine;

public class SpawnGroundTrigger : MonoBehaviour
{
    public event Action Triggered;

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (gameObject.activeInHierarchy == false)
            return;
        
        if (collider.TryGetComponent(out Ground ground))
            Triggered?.Invoke();
    }
}
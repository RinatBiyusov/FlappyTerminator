using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Died;
    
    public void TakeDamage() =>
        Died?.Invoke();
}
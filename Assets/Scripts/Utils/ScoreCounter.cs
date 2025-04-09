using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        GameEvents.EnemyDied += Add;
    }

    private void OnDisable()
    {
        GameEvents.EnemyDied -= Add;
    }
    
    private void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
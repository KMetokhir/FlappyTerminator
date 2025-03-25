using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemyRemover _enemyRemover;

    private uint _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _enemyRemover.EnemyRemoved += OnEnemyRemoved;
    }

    private void Start()
    {
        ScoreChanged?.Invoke((int)_score);
    }

    private void OnDisable()
    {
        _enemyRemover.EnemyRemoved -= OnEnemyRemoved;
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke((int)_score);
    }

    private void OnEnemyRemoved()
    {
        _score++;
        ScoreChanged?.Invoke((int)_score);
    }
}
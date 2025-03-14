using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private uint _score;

    public event Action<int> ScoreChanged;

   public void Add()
    {
        _score++;
        ScoreChanged?.Invoke((int)_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke((int)_score);
    }
}

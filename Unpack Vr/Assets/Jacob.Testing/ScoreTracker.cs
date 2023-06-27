using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score;

    private void OnEnable()
    {
        score = 0;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void RemoveScore(int value) 
    { 
        score -= value;
    }

}

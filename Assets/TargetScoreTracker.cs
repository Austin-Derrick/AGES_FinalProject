using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScoreTracker : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    TargetScoreUpdater scoreUpdater;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void UpdatePoints(int Value)
    {
        score += Value;
        scoreUpdater.UpdateText(score);
    }
}

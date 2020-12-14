using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    int scoreValue = 0;
    [SerializeField]
    TargetScoreTracker scoreTracker;
    private void OnCollisionEnter(Collision collision)
    {
        scoreTracker.UpdatePoints(scoreValue);
    }
}

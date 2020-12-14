using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetScoreUpdater : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: 0";
    }

    public void UpdateText(int score)
    {
        scoreText.text = $"SCORE: {score}";
    }
}

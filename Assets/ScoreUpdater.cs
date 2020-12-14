using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreUpdater : MonoBehaviour
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

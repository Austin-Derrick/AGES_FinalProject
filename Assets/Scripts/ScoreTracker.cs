using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score { get; private set; }
    [SerializeField]
    ScoreUpdater scoreText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Milkjug"))
        {
            score++;
            scoreText.UpdateText(score);
        }
    }

    void ResetScore()
    {
        score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
}

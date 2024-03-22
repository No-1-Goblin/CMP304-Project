using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] Text text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        eventHandler.awardPoints.AddListener(AddScore);
        eventHandler.killPlayer.AddListener(ResetScore);
        eventHandler.resetGame.AddListener(ResetScore);
        text.text = "Score: " + score;
    }

    void AddScore(bool positive)
    {
        if (positive)
        {
            score ++;
            text.text = "Score: " + score;
        }
    }

    void ResetScore()
    {
        score = 0;
        text.text = "Score: " + score;
    }
}

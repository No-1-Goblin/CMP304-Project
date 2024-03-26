using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Tester : MonoBehaviour
{
    [SerializeField] string fileName;
    [SerializeField] int testsToRun;
    [SerializeField] EventHandler eventHandler;
    [SerializeField] Slider timescaleSlider;

    int score = 0;
    int deaths = 0;
    [SerializeField] int testsRan = 0;
    // Start is called before the first frame update
    void Start()
    {
        eventHandler.awardPoints.AddListener(AddScore);
        eventHandler.killPlayer.AddListener(AddDeath);
        eventHandler.resetGame.AddListener(ResetScore);
        eventHandler.resetGame.AddListener(ResetDeaths);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void WriteToFile(string text, string fileName)
    {
        StreamWriter sr;
        if (File.Exists(fileName + ".csv"))
        {
            sr = File.AppendText(fileName + ".csv");
        }
        else
        {
            sr = File.CreateText(fileName + ".csv");
        }
        sr.WriteLine(text);
        sr.Close();
    }

    void AddScore(bool positive)
    {
        if (positive)
        {
            score++;
        }
        if (score >= 100)
        {
            WriteToFile(deaths + ", " + score, fileName + "_ScorePerLife");
            WriteToFile(deaths.ToString(), fileName + "_DeathsToReachPerfection");
            testsRan++;
            if (testsRan < testsToRun)
            {
                eventHandler.resetGame.Invoke();
            } else
            {
                timescaleSlider.value = 0;
            }
        }
    }

    void AddDeath()
    {
        WriteToFile(deaths + ", " + score, fileName + "_ScorePerLife");
        deaths++;
        ResetScore();
    }

    void ResetScore()
    {
        score = 0;
    }

    void ResetDeaths()
    {
        deaths = 0;
    }
}

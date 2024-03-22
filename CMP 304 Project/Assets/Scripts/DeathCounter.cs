using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] Text text;
    int deaths = 0;
    // Start is called before the first frame update
    void Start()
    {
        eventHandler.killPlayer.AddListener(AddDeath);
        eventHandler.resetGame.AddListener(ResetDeaths);
        text.text = "Deaths: " + deaths;
    }

    void AddDeath()
    {
        deaths++;
        text.text = "Deaths: " + deaths;
    }

    void ResetDeaths()
    {
        deaths = 0;
        text.text = "Deaths: " + deaths;
    }
}

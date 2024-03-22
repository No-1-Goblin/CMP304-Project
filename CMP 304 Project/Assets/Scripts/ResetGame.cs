using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    [SerializeField] EventHandler eventHandler;
    
    public void OnClicked()
    {
        eventHandler.resetGame.Invoke();
    }
}

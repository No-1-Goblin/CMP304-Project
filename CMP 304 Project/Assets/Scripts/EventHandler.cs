using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu (fileName = "Event Handler")]
public class EventHandler : ScriptableObject
{
    public UnityEvent<bool> awardPoints;
    public UnityEvent killPlayer;
    public UnityEvent resetGame;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTriggerResponse : MonoBehaviour
{
    [SerializeField] EventHandler eventHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            eventHandler.awardPoints.Invoke(false);
            eventHandler.killPlayer.Invoke();
        }
    }
}

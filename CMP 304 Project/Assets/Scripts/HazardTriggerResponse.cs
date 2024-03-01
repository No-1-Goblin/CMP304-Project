using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTriggerResponse : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player");
        }
    }
}

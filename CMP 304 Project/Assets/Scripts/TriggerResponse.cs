using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerResponse : MonoBehaviour
{
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            playerMovement.Jump();
        }
    }
}

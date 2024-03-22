using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerStanding, playerDucking;
    [SerializeField] EventHandler eventHandler;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        eventHandler.killPlayer.AddListener(Die);
        eventHandler.resetGame.AddListener(Die);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Duck()
    {

        playerDucking.gameObject.SetActive(true);
        playerStanding.gameObject.SetActive(false);
    }

    public void Stand()
    {
        playerStanding.gameObject.SetActive(true);
        playerDucking.gameObject.SetActive(false);
    }

    public void Jump()
    {
        Stand();
        rb.AddForceY(400);
    }

    void Die()
    {
        transform.position = new Vector2(0, 0);
    }
}

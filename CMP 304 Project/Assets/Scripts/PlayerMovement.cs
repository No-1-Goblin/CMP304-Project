using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerStanding, playerDucking;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Duck();
        } else
        {
            Stand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
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
        rb.AddForceY(400);
    }
}

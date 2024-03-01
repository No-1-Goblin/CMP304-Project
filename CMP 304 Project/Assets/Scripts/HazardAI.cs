using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardAI : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] EventHandler eventHandler;
    [SerializeField] public ApproachingHazards hazardType;
    bool awardedScore = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eventHandler.killPlayer.AddListener(OnPlayerDeath);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        rb.velocityX = -5;

        if (transform.position.x <= -1.28f && !awardedScore)
        {
            awardedScore = true;
            eventHandler.awardPoints.Invoke(true);
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnPlayerDeath()
    {
        Destroy(gameObject);
    }
}

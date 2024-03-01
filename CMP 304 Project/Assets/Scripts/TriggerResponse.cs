using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerResponse : MonoBehaviour
{
    Brain brain;
    // Start is called before the first frame update
    void Start()
    {
        brain = GetComponentInParent<Brain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            brain.AlertBrain(collision.gameObject.GetComponent<HazardAI>().hazardType);
        }
    }
}

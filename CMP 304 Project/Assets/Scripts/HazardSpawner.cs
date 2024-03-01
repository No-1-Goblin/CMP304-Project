using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    float timeSinceLastHazard = 0;
    [SerializeField] List<GameObject> hazards;
    // Update is called once per frame
    void Update()
    {
        timeSinceLastHazard += Time.deltaTime;
        if (timeSinceLastHazard >= 1.5)
        {
            if (Random.Range(0f, 10f) <= timeSinceLastHazard)
            {
                Instantiate(hazards[Random.Range(0, hazards.Count)]);
                timeSinceLastHazard = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] int hazardTypes, actionTypes;
    [SerializeField] float learningRate = 0.1f, discountFactor = 0.8f, positiveReward = 10, negativeReward = -100;
    PlayerMovement playerMovement;
    float[,] Q;
    ApproachingHazards lastHazard;
    Actions actionTaken;
    [SerializeField] int oddsToRandomise = 20;
    // Start is called before the first frame update
    void Start()
    {
        // Setup event handler listeners
        eventHandler.awardPoints.AddListener(AssignReward);
        eventHandler.killPlayer.AddListener(RemoveRandomness);
        // Get player movement component
        playerMovement = GetComponent<PlayerMovement>();
        // Reset brain
        ResetBrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBrain()
    {
        // Reset Q matrix
        Q = new float[hazardTypes, actionTypes];
        oddsToRandomise = 20;
    }

    public void AlertBrain(ApproachingHazards newHazard)
    {
        // Update memory of last hazard
        lastHazard = newHazard;
        // Determine action to take
        actionTaken = DetermineAction(newHazard);
        // Perform determined action
        PerformAction(actionTaken);
    }

    public void AssignReward(bool positive)
    {
        // Determine whether to reward a positive reward or negative punishment
        float reward = positive ? positiveReward : negativeReward;
        // Apply changes to Q matrix
        Q[(int)lastHazard, (int)actionTaken] = Q[(int)lastHazard, (int)actionTaken] + learningRate * 
        (reward + discountFactor * GetBestAction(lastHazard).Item2 - Q[(int)lastHazard, (int)actionTaken]);
    }

    Actions DetermineAction(ApproachingHazards hazard)
    {
        // Calculate best action based on Q matrix
        Actions actionToPerform = GetBestAction(hazard).Item1;
        // Random chance to perform random action instead
        if (UnityEngine.Random.Range(1, 101) <= oddsToRandomise)
        {
            actionToPerform = (Actions)UnityEngine.Random.Range(0, actionTypes);
            Debug.Log("I'm performing a random action");
        }
        return actionToPerform;
    }

    Tuple<Actions, float> GetBestAction(ApproachingHazards hazard)
    {
        // Create variable to hold best action found so far
        Tuple<Actions, float> bestAction = new((Actions)0, Q[(int)hazard, 0]);
        // Iterate through all actions for currently approaching hazard in Q matrix
        for (int i = 0; i < actionTypes; i++)
        {
            // If the action currently being checked has a greater expected reward than the previously best found action
            if (Q[(int)hazard, i] > bestAction.Item2)
            {
                // Update best action
                bestAction = new((Actions)i, Q[(int)hazard, i]);
            }
            // If the action has an equal expected reward to the previously best found action
            else if (Q[(int)hazard, i] == bestAction.Item2)
            {
                // Choose a random action out of the two
                bestAction = UnityEngine.Random.Range(0, 2) == 0 ? bestAction : new((Actions)i, Q[(int)hazard, i]);
            }
        }
        return bestAction;
    }

    void PerformAction(Actions actionToTake)
    {
        switch (actionToTake)
        {
            case Actions.Jump:
                playerMovement.Jump();
                break;
            case Actions.Duck:
                playerMovement.Duck();
                break;
            case Actions.Stand:
                playerMovement.Stand();
                break;
        }
        // Keep record of last action taken
        actionTaken = actionToTake;
        Debug.Log("Approaching hazard was a: " + lastHazard);
        Debug.Log("I chose to " + actionTaken);
    }

    void RemoveRandomness()
    {
        if (oddsToRandomise != 0)
        {
            oddsToRandomise -= 5;
        } else
        {
            oddsToRandomise = 20;
        }
    }
}

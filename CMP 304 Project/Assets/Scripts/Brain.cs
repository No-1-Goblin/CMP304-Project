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
        eventHandler.awardPoints.AddListener(AssignReward);
        eventHandler.killPlayer.AddListener(RemoveRandomness);
        playerMovement = GetComponent<PlayerMovement>();
        ResetBrain();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetBrain()
    {
        Q = new float[hazardTypes, actionTypes];
        oddsToRandomise = 20;
    }

    public void AlertBrain(ApproachingHazards newHazard)
    {
        lastHazard = newHazard;
        actionTaken = DetermineAction(newHazard);
        PerformAction(actionTaken);
    }

    public void AssignReward(bool positive)
    {
        float reward = positive ? positiveReward : negativeReward;
        Q[(int)lastHazard, (int)actionTaken] = Q[(int)lastHazard, (int)actionTaken] + learningRate * (reward + discountFactor * GetBestAction(lastHazard).Item2 - Q[(int)lastHazard, (int)actionTaken]);
    }

    Actions DetermineAction(ApproachingHazards hazard)
    {
        Actions actionToPerform = GetBestAction(hazard).Item1;
        if (UnityEngine.Random.Range(1, 101) <= oddsToRandomise)
        {
            actionToPerform = (Actions)UnityEngine.Random.Range(0, actionTypes);
            Debug.Log("I'm performing a random action");
        }
        return actionToPerform;
    }

    Tuple<Actions, float> GetBestAction(ApproachingHazards hazard)
    {
        Tuple<Actions, float> bestAction = new((Actions)0, Q[(int)hazard, 0]);
        for (int i = 0; i < actionTypes; i++)
        {
            if (Q[(int)hazard, i] > bestAction.Item2)
            {
                bestAction = new((Actions)i, Q[(int)hazard, i]);
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
        actionTaken = actionToTake;
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

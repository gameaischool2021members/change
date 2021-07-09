using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;



/*
    Defines Human Proxy Action Space
*/
public enum ActionSpace {
    StandStill = 0,
    MoveRight,
    MoveLeft,
    MoveForward,
    MoveBackward
}

/*
    Hack for Learning purposes.
    Simulates human action. Randomly.
*/
public class HumanProxy {
    public int getAction() {
        //int move = UnityEngine.Random.Range(0,5);
        int move = UnityEngine.Random.Range(1, 3);
        return move;
    }
}

/*
    Defines Target Observer. Purpose is based on HumanProxy Movement
    select current 'intent'
*/
class HumanProxyIntentClassifier {
    public int targetID = 0;
    public ActionSpace learningMove;

    public Transform target_Left;
    public Transform target_Right;

    public Transform emptyTarget;
    public Transform targetSelection() {
        emptyTarget = new GameObject().transform;
        target_Left = GameObject.FindGameObjectsWithTag("1")[0].transform;
        target_Right = GameObject.FindGameObjectsWithTag("2")[0].transform;

        switch (learningMove) {
            case ActionSpace.StandStill:
            case ActionSpace.MoveForward:
            case ActionSpace.MoveBackward:
                targetID = 0;
                break;
            case ActionSpace.MoveRight:
                targetID = 2;
                break;
            case ActionSpace.MoveLeft:
                targetID = 1;
                break;
            default:
                break;
        }

        if (targetID == 1) {
            return target_Left;
        } else if (targetID == 2) {
            return target_Right;
        } 
        else {
            return emptyTarget;
        }
    }
}

public class IntentPredictingAgent : Agent
{
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.W))
        {
            discreteActionsOut[0] = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[0] = 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[0] = 4;
        }
    }

    Rigidbody rBody;
    void Start () {
        rBody = GetComponent<Rigidbody>();
    }

    public Transform Target;
    public Transform PlayerPosition_original = null;
    public Transform PlayerPosition_old;
    public Transform PlayerPosition_new;
    HumanProxyIntentClassifier proxyCC;

    float episodeStartTime = 0;
    int nrActionsInEpisode = 0;

    public override void OnEpisodeBegin()
    {
        Debug.Log("OnEpisodeBegin");
        /*
            Emulate Human Move
        */
        HumanProxy proxy = new HumanProxy();
        HumanProxyIntentClassifier proxyC = new HumanProxyIntentClassifier();
        proxyCC = proxyC;
        proxyC.learningMove = (ActionSpace)proxy.getAction();
        Target = proxyC.targetSelection();

        GameObject playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        GameObject aiAgent = GameObject.FindGameObjectsWithTag("AI")[0];
        AiController aiController = aiAgent.GetComponent<AiController>();
        playerController.ResetPosition();
        aiController.ResetPosition();
        PlayerPosition_old = playerObject.transform;

        playerController.Move(proxyC.learningMove);

        PlayerPosition_new = playerObject.transform;
        episodeStartTime = Time.realtimeSinceStartup;
        nrActionsInEpisode = 0;
        Debug.Log("Intended Target Tag = " + Target.tag);
        Debug.Log("Player Moved --> " + proxyC.learningMove);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Debug.Log("CollectObservations");
        // Human Position
        sensor.AddObservation(PlayerPosition_old.localPosition);//3
        sensor.AddObservation(PlayerPosition_new.localPosition);//3
        sensor.AddObservation(this.transform.localPosition);//3

        // Agent velocity
        sensor.AddObservation(proxyCC.target_Left.localPosition);//3
        sensor.AddObservation(proxyCC.target_Right.localPosition);//3

        // action space of total 15 floats
    }
    public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Debug.Log("OnActionReceived");
        // Actions, discrete size = 5
        int movement = actionBuffers.DiscreteActions[0];
        GameObject aiAgent = GameObject.FindGameObjectsWithTag("AI")[0];
        AiController aiController = aiAgent.GetComponent<AiController>();
        switch (movement)
        {
            case 0: aiController.Move(ActionSpace.StandStill); break;
            case 1: aiController.Move(ActionSpace.MoveForward); break;
            case 2: aiController.Move(ActionSpace.MoveRight); break;
            case 3: aiController.Move(ActionSpace.MoveBackward); break;
            case 4: aiController.Move(ActionSpace.MoveLeft); break;
        }
        nrActionsInEpisode++;

        // Rewards
        GridMap map = GridMap.GetInstance();
        float worldPosX = map.GetWorldPosX(aiController.GetGridPosX());
        float worldPosZ = map.GetWorldPosZ(aiController.GetGridPosZ());
        float distanceToTarget = Vector3.Distance( new Vector3(worldPosX, 0, worldPosZ), Target.localPosition);
        //float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < 1.5f)
        {
            SetReward(10.0f);
            EndEpisode();
        }
        else if (nrActionsInEpisode > 50)
        {
            float rewardValue = (10.0f / (10.0f + distanceToTarget)) - 5; // max 5, min ~ -5
            SetReward(rewardValue);
            EndEpisode();
        }
    }
}

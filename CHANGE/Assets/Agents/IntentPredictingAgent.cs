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
        int move = UnityEngine.Random.Range(0,5);
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
    public Transform PlayerPosition_old;
    public Transform PlayerPosition_new;
    HumanProxyIntentClassifier proxyCC;
    public override void OnEpisodeBegin()
    {
        /*
            Emulate Human Move
        */
        HumanProxy proxy = new HumanProxy();
        HumanProxyIntentClassifier proxyC = new HumanProxyIntentClassifier();
        proxyCC = proxyC;
        proxyC.learningMove = (ActionSpace)proxy.getAction();
        Target = proxyC.targetSelection();

        Transform localAgent = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        GameObject a = GameObject.FindGameObjectsWithTag("Player")[0];
        PlayerPosition_old = a.transform;
        PlayerController playerController = a.GetComponent<PlayerController>();
        
        playerController.Move(proxyC.learningMove);

        PlayerPosition_new = a.transform;
        Debug.Log("Intended Target Tag = " + Target.tag);
        Debug.Log("Player Moved --> " + proxyC.learningMove);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
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
        // Actions, discrete size = 5
        int movement = actionBuffers.DiscreteActions[0];
        GameObject aiAgent = GameObject.FindGameObjectsWithTag("AI")[0];
        AiController aiController = aiAgent.GetComponent<AiController>();
        switch (movement) {
            case 0: aiController.Move(ActionSpace.StandStill); break;
            case 1: aiController.Move(ActionSpace.MoveForward);break;
            case 2: aiController.Move(ActionSpace.MoveRight);break;
            case 3: aiController.Move(ActionSpace.MoveBackward); break;
            case 4: aiController.Move(ActionSpace.MoveLeft); break;
        }

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < 1.5f)
        {
            SetReward(1.0f);
            EndEpisode();
        } else {
            SetReward(-1.0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;



/*
    Defines Human Proxy Action Space
*/
enum ActionSpace {
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
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }

    Rigidbody rBody;
    void Start () {
        rBody = GetComponent<Rigidbody>();
    }

    public Transform Target;
    public override void OnEpisodeBegin()
    {
        /*
            Emulate Human Move
        */
        HumanProxy proxy = new HumanProxy();
        HumanProxyIntentClassifier proxyC = new HumanProxyIntentClassifier();
        proxyC.learningMove = (ActionSpace)proxy.getAction();
        Target = proxyC.targetSelection();

        Debug.Log(Target.tag);

       // If the Agent fell, zero its momentum
        if (this.transform.localPosition.y < 0)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3( 0, 0.5f, 0);
        }

        // Move the target to a new spot
        Target.localPosition = new Vector3(Random.value * 8 - 4,
                                           0.5f,
                                           Random.value * 8 - 4);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        // Agent velocity
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }
    public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        rBody.AddForce(controlSignal * forceMultiplier);

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        // Fell off platform
        else if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }
}

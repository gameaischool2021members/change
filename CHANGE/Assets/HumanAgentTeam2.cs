using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAgentTeam2 : MonoBehaviour
{
    public float speedHumanAgent = 2;
    public AbstractAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = new HumanAgent();
        //agent = new RandomAgent();
    }

    // Update is called once per frame
    void Update()
    {
        EAction action = agent.GetAction();
        if (action == EAction.S)
        {
            transform.Translate(0, 0, -speedHumanAgent * Time.deltaTime);
        }
        else if (action == EAction.W)
        {
            transform.Translate(0, 0, speedHumanAgent * Time.deltaTime);
        }
        else if (action == EAction.A)
        {
            transform.Translate(-speedHumanAgent * Time.deltaTime, 0, 0);
        }
        else if (action == EAction.D)
        {
            transform.Translate(speedHumanAgent * Time.deltaTime, 0, 0);
        }
    }
}

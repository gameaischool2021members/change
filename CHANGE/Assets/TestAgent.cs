using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAgent : MonoBehaviour
{
    public float speed = 2;
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
        if (action == EAction.MoveDown)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        else if (action == EAction.MoveUp)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (action == EAction.MoveLeft)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (action == EAction.MoveRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}

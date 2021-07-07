using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAgent : AbstractAgent
{
    public float timeBetweenDirectionChange = 1;
    float timeSinceLastDirectionChange = 999;
    EAction currentAction = EAction.None;
    public override EAction GetAction()
    {
        // We should probably get the world state as input here somewhere
        timeSinceLastDirectionChange += Time.deltaTime;

        if (timeSinceLastDirectionChange >= timeBetweenDirectionChange)
        {
            timeSinceLastDirectionChange = 0;

            int rndInt = (int)(Random.value * 4);
            if (rndInt == 0)
            {
                currentAction = EAction.MoveRight;
            }
            else if (rndInt == 1)
            {
                currentAction = EAction.MoveLeft;
            }
            else if (rndInt == 2)
            {
                currentAction = EAction.MoveUp;
            }
            else if (rndInt == 3)
            {
                currentAction = EAction.MoveDown;
            }
        }
        return currentAction;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAgent : AbstractAgent
{
    public override EAction GetAction()
    {
        EAction currentAction = EAction.None;
        int rndInt = (int)(Random.value * 4);
        Debug.Log(rndInt);
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
        return currentAction;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAgent : AbstractAgent
{
    public override EAction GetAction()
    {
        // We should probably get the world state as input here somewhere
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return EAction.MoveRight;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            return EAction.MoveLeft;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            return EAction.MoveUp;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return EAction.MoveDown;
        }
        return EAction.None;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractAgent
{
    public virtual EAction GetAction()
    {
        // We should probably get the world state as input here somewhere
        return EAction.MoveDown;
    }
}

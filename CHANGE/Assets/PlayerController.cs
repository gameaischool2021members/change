using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    public AbstractAgent agent;

    private int gridPosX = 0;
    private int gridPosZ = 0;
    private int originalGridPosX = 0;
    private int originalGridPosZ = 0;

    private float timeSinceLastAction = 999;
    public float timeBetweenActions = 0.3f;

    public void ResetPosition()
    {
        gridPosX = originalGridPosX;
        gridPosZ = originalGridPosZ;
        GridMap map = GridMap.GetInstance();
        float diffX = map.GetWorldPosX(gridPosX) - transform.position.x;
        float diffZ = map.GetWorldPosZ(gridPosZ) - transform.position.z;
        transform.Translate(diffX, 0, diffZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerController::Start");
        agent = new HumanAgent();
    }

    // Update is called once per frame
    public void Move(ActionSpace action) {
        GridMap map = GridMap.GetInstance();
        //timeSinceLastAction += Time.deltaTime;

        if (action == ActionSpace.MoveBackward)
        {
            if (map.IsWalkable(gridPosX, gridPosZ + 1))
            {
                gridPosZ += 1;
                Debug.Log("BACK");
            }
        }
        else if (action == ActionSpace.MoveForward)
        {
            if (map.IsWalkable(gridPosX, gridPosZ - 1))
            {
                gridPosZ -= 1;
                Debug.Log("FRONT");
            }
        }
        else if (action == ActionSpace.MoveLeft)
        {
            if (map.IsWalkable(gridPosX + 1, gridPosZ))
            {
                gridPosX += 1;
                Debug.Log("LEFT");
            }
        }
        else if (action == ActionSpace.MoveRight)
        {
            if (map.IsWalkable(gridPosX - 1, gridPosZ))
            {
                gridPosX -= 1;
                Debug.Log("RIGHT");
            }
        }

        //float targetPosX = map.GetWorldPosX(gridPosX);
        //float targetPosZ = map.GetWorldPosZ(gridPosZ);
        //float diffX = targetPosX - transform.position.x;
        //float diffZ = targetPosZ - transform.position.z;
        //transform.Translate(diffX * 0.01f, 0, 0);
        //transform.Translate(0, 0, diffZ * 0.01f);
    }
    
    void Update()
    {
        GridMap map = GridMap.GetInstance();
        timeSinceLastAction += Time.deltaTime;
        if (timeSinceLastAction >= timeBetweenActions)
        {
        //    EAction action = agent.GetAction();
        //    if (action != EAction.None)
        //    {
                timeSinceLastAction = 0; // reset timer
        //    }
        //    if (action == EAction.MoveDown)
        //    {
        //        if (map.IsWalkable(gridPosX, gridPosZ + 1))
        //        {
        //            gridPosZ += 1;
        //        }
        //    }
        //    else if (action == EAction.MoveUp)
        //    {
        //        if (map.IsWalkable(gridPosX, gridPosZ - 1))
        //        {
        //            gridPosZ -= 1;
        //        }
        //    }
        //    else if (action == EAction.MoveLeft)
        //    {
        //        if (map.IsWalkable(gridPosX + 1, gridPosZ))
        //        {
        //            gridPosX += 1;
        //        }
        //    }
        //    else if (action == EAction.MoveRight)
        //    {
        //        if (map.IsWalkable(gridPosX - 1, gridPosZ))
        //        {
        //            gridPosX -= 1;
        //        }
        //    }
        }

        float targetPosX = map.GetWorldPosX(gridPosX);
        float targetPosZ = map.GetWorldPosZ(gridPosZ);
        float diffX = targetPosX - transform.position.x;
        float diffZ = targetPosZ - transform.position.z;
        transform.Translate(diffX * 1.0f, 0, diffZ * 1.0f);
    }

    public void SetGridPos(int x, int z, bool saveAsOriginal = false)
    {
        gridPosX = x;
        gridPosZ = z;
        if (saveAsOriginal)
        {
            originalGridPosX = x;
            originalGridPosZ = z;
        }
    }

    public int GetGridPosX()
    {
        return gridPosX;
    }
    public int GetGridPosZ()
    {
        return gridPosZ;
    }
}

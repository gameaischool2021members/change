using System.Collections;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using UnityEngine;

public class GenerateMazeMain : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Player;
    public GameObject AiSupporter;
    public GameObject Target;
    
    // Start is called before the first frame update
    void Start ()
    {
        GridMap map = GridMap.GetInstance();

        //string WorldFile = "world_0_eg";
        string WorldFile = "world_2";
        TextAsset t1 = (TextAsset)Resources.Load(WorldFile, typeof(TextAsset));
        string s = t1.text;
        // Assumes all lines have the same width
        string[] lines = s.SplitLines();
        int nrRows = lines.Length;
        int nrCols = lines[0].Length;
        map.SetDimensions(nrRows, nrCols);
        for (int lineIdx = 0; lineIdx<lines.Length; lineIdx++)
        {
            string line = lines[lineIdx];
            for (int colIdx = 0; colIdx < line.Length; colIdx++)
            {
                float posX = map.GetWorldPosX(colIdx);
                float posZ = map.GetWorldPosZ(lineIdx);
                char value = line[colIdx];
                if (value == '1') // wall
                {
                    GameObject t = Instantiate(Wall, new Vector3(posX, 1.5f, posZ), Quaternion.identity);
                }
                else if (value == '5') // target?
                {
                    GameObject t = Instantiate(Target, new Vector3(posX, 1.5f, posZ), Quaternion.identity);
                }
                else if (value == '8') // AI agent
                {
                    Debug.Log("Instantiation AiSupporter");
                    GameObject t = Instantiate(AiSupporter, new Vector3(posX, 3.5f, posZ), Quaternion.identity);
                    AiController aiController = t.GetComponent<AiController>();
                    aiController.SetGridPos(colIdx, lineIdx);
                }
                else if (value == '9') // player
                {
                    Debug.Log("Instantiation Player");
                    GameObject t = Instantiate(Player, new Vector3(posX, 3.5f, posZ), Quaternion.identity);
                    PlayerController playerController = t.GetComponent<PlayerController>();
                    playerController.SetGridPos(colIdx, lineIdx);
                }
                map.SetAt(value, lineIdx, colIdx);
            }
        }
    }
}

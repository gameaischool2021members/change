using System.Collections;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using UnityEngine;

public class GenerateMazeMainEscortAgentScene : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Goal;
    public Transform TargetForTeam1;
    public Transform TargetLightingForTeam1;
    public Transform TargetForTeam2;
    public Transform TargetLightingForTeam2;
    public Transform HumanPlayerTeam1;
    public Transform AIAgentTeam1;
    public Transform HumanPlayerTeam2;
    public Transform AIAgentTeam2;
 
    // Start is called before the first frame update
    void Start ()
    {
        // TODO: move initial asset object to level meta data config file
        TargetForTeam1.localPosition = new Vector3(-18.3f, 0.9f, 27.5f);
        TargetLightingForTeam1.localPosition = new Vector3(-18.3f, 7.9f, 27.5f);
        TargetForTeam2.localPosition = new Vector3(-18.3f, 0.9f, -27.5f);
        TargetLightingForTeam2.localPosition = new Vector3(-18.3f, 7.9f, -27.5f);
        HumanPlayerTeam1.localPosition = new Vector3(11f, 1.14f, -13f);
        AIAgentTeam1.localPosition = new Vector3(4f, 3.04f, -20f);
        HumanPlayerTeam2.localPosition = new Vector3(11f, 1.14f, 13f);
        AIAgentTeam2.localPosition = new Vector3(4f, 3.04f, 20f);

        string WorldFile = "world_escort_agent_scene";
        //string WorldFile = "world_0_eg";
        //string WorldFile = "world_2";
        TextAsset t1 = (TextAsset)Resources.Load(WorldFile, typeof(TextAsset));
        string s = t1.text;
        // Assumes all lines have the same width
        string[] lines = s.SplitLines();
        for (int lineIdx = 0; lineIdx<lines.Length; lineIdx++)
        {
            string line = lines[lineIdx];
            for (int colIdx = 0; colIdx < line.Length; colIdx++)
            {
                if (line[colIdx] == '1') // wall
                {
                    GameObject t = Instantiate(Wall, new Vector3(50 - colIdx * 10, 1.5f, 50 - lineIdx * 10), Quaternion.identity);
                }
                else if (line[colIdx] == '5') // goal?
                {
                    GameObject t = Instantiate(Goal, new Vector3(50 - colIdx * 10, 1.5f, 50 - lineIdx * 10), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

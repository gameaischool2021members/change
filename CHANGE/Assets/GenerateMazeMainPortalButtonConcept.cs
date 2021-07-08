using System.Collections;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using UnityEngine;

public class GenerateMazeMainPortalButtonConcept : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Goal;
    public Transform TargetForTeam;
    public Transform TargetLightingForTeam;
    public Transform HumanPlayer;
    public Transform AIAgent;
 
    // Start is called before the first frame update
    void Start ()
    {
        // TODO: move initial asset object to level meta data config file
        TargetForTeam.localPosition = new Vector3(-30f, 0.9f, -30f);
        TargetLightingForTeam.localPosition = new Vector3(-30f, 7.9f, -30f);
        HumanPlayer.localPosition = new Vector3(-5f, 1.14f, 12f);
        AIAgent.localPosition = new Vector3(-20f, 3.04f, 30f);

        string WorldFile = "world_portal_button_scene";

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
                else if (line[colIdx] == '2') // door
                {
                    GameObject t = Instantiate(Door1, new Vector3(50 - colIdx * 10, 1.5f, 50 - lineIdx * 10), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

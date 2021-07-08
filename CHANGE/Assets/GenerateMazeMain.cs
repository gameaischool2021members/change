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
        // TODO: move initial asset object to level meta data config file

        //string WorldFile = "world_0_eg";
        string WorldFile = "world_2";
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
                else if (line[colIdx] == '5') // target?
                {
                    GameObject t = Instantiate(Target, new Vector3(50 - colIdx * 10, 1.5f, 50 - lineIdx * 10), Quaternion.identity);
                }
                else if (line[colIdx] == '8') // AI agent
                {
                    Debug.Log("Instantiation AiSupporter");
                    GameObject t = Instantiate(AiSupporter, new Vector3(50 - colIdx * 10, 3.5f, 50 - lineIdx * 10), Quaternion.identity);
                }
                else if (line[colIdx] == '9') // player
                {
                    Debug.Log("Instantiation Player");
                    GameObject t = Instantiate(Player, new Vector3(50 - colIdx * 10, 3.5f, 50 - lineIdx * 10), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

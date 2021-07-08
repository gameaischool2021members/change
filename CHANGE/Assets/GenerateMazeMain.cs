using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMazeMain : MonoBehaviour
{
    public GameObject Wall;
    public Transform Target;
    public Transform TargetLighting;
    public Transform HumanPlayer;
    public Transform AIAgent;
    public Transform Enemy;
    public Transform Treasure;
    
    // Start is called before the first frame update
    void Start ()
    {
        // TODO: move initial asset object to level meta data config file
        Target.localPosition = new Vector3(-18.3f, 0.9f, 27.5f);
        TargetLighting.localPosition = new Vector3(-18.3f, 7.9f, 27.5f);
        HumanPlayer.localPosition = new Vector3(-5f, 1.14f, -8f);
        AIAgent.localPosition = new Vector3(35f, 2f, -25f);
        Enemy.localPosition = new Vector3(-28f, 0.9f, 1.5f);
        Treasure.localPosition = new Vector3(35f, 0.8f, 30f);

        string WorldFile = "world_0_eg";
        //string WorldFile = "world_2";
        TextAsset t1 = (TextAsset)Resources.Load(WorldFile, typeof(TextAsset));
        string s = t1.text;
        s = s.Replace("\n", "");
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                int column, row;
                column = i % 10;
                row = i / 10;
                GameObject t;
                t = (GameObject)(Instantiate(Wall, new Vector3(50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
            }
        }
        //GameObject t;
        //t = (GameObject)(Instantiate (player, new Vector3 (50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
    }
}

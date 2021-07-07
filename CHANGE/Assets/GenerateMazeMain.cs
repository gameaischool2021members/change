using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMazeMain : MonoBehaviour
{
    public GameObject wall;
    //public GameObject player;
    
    // Start is called before the first frame update
    void Start ()
    {
    
        TextAsset t1 = (TextAsset)Resources.Load("world_0_eg", typeof(TextAsset));
    
        string s = t1.text;
    
        int i, j;
    
        s = s.Replace("\n","");
    
        for (i = 0; i < s.Length; i++)
    
        {
    
            if (s [i] == '1')
    
            {
    
                int column, row;
    
                column = i%10;
    
                row = i / 10;
    
                GameObject t;
    
                t = (GameObject)(Instantiate (wall, new Vector3 (50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
    
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

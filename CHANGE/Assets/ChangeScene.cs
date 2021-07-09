using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("GameLevelAuto");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("gameLevelAutoEscortAgentScene");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("gameLevelAutoPortalButtonConcept");
    }
    public void Scene4()
    {
        SceneManager.LoadScene("collaborative_dungeon");
    }
}
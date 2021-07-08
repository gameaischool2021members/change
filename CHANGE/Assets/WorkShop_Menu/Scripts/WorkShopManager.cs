using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class WorkShopManager : MonoBehaviour
{

  // -----------------------------------------
  // Variables
  // -----------------------------------------

  [Space]
  [Header ("Project Button Data")]
  public GameObject projectButtonsPreFab;
  public GameObject projectButtonsParent;
  public Vector3 projectButtonsPosStart;
  public int projectButtonsPosOffsetY;

  [Space]
  [Header ("Scene Button Data")]
  public GameObject sceneButtonPreFab;
  public GameObject sceneButtonsParent;
  public Vector3 sceneButtonsPosStart;
  public int sceneButtonsPossOffsetY;

  [Space]
  [Header ("Menu GameObjects")]
  public GameObject projectsMenu;
  public GameObject projectsScenesMenu;
  public GameObject mainMenu;

  [Space]
  [Header ("Meta")]
  [Tooltip ("This should have a size of at least 1 and be where your project directories are located.")]
  public string[] paths;
  [Tooltip ("This should be the path back to your WorkShop menu scene.  It will be used to return to this scene from your other project scenes.  This only works if DestroyOnLoad is set to false")]
  public string devWorkShopMenuPath;
  [Tooltip ("Weather or not this object should be destroyed when loading a new scene or not")]
  public bool DestroyOnLoad = false;
  [Tooltip ("The button used to return to this scene")]
  public string returnToMenuButton;

  [Space]
  [Header ("Lists")]
  [Tooltip ("This will be gereated by the script and can be viewed here for debugging")]
  public List<string> projectPaths = new List<string>();
  [Tooltip ("This will be gereated by the script and can be viewed here for debugging")]
  public List<string> scenePaths = new List<string>();

  [Space]
  [Header ("Info")]
  public string info;
  public TextMeshProUGUI infoTextMeshPro;

  [Space]
  [Header ("Debugging")]
  [Tooltip ("Will write a console line every time a function starts and ends EXCEPT FOR THE FUNCTION Update()")]
  public bool functionStartAndEnding = false;
  public bool listsBeingUpdated = false;
  public bool fileBeingProcessed = false;

  // -----------------------------------------
  // Start and Update functions
  // -----------------------------------------

  public void Start()
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function Start() has started");

    // -----------------------------------------

    setUpChecker();

    if(!DestroyOnLoad) DontDestroyOnLoad(this.gameObject);
    UpdateUIProjectButtons();
    infoTextMeshPro.text = info;

    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function Start() has ended");
  }

  public void Update()
  {
    if(Input.GetKeyDown(returnToMenuButton))
    {
      Debug.Log("Returning to WorkShop Menu");
      returnToWorkShopMenu(devWorkShopMenuPath);
    }
  }

  public void setUpChecker ()
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function setUpChecker() has started");

    // -----------------------------------------
    if (projectButtonsPreFab == null) Debug.LogError("projectButtonsPreFab must be set", projectButtonsPreFab);
    else if (projectButtonsParent == null) Debug.LogError("projectButtonsParent must be set", projectButtonsParent);
    else if (sceneButtonPreFab == null) Debug.LogError("sceneButtonPreFab must be set", sceneButtonPreFab);
    else if (sceneButtonsParent == null) Debug.LogError("sceneButtonsParent must be set", sceneButtonsParent);
    else if (projectsMenu == null) Debug.LogError("projectsMenu must be set", projectsMenu);
    else if (projectsScenesMenu == null) Debug.LogError("projectsScenesMenu must be set", projectsScenesMenu);
    else if (mainMenu == null) Debug.LogError("mainMenu must be set", mainMenu);
    else if (1 > paths.Length) Debug.LogError("there must be at least on path set must be set");
    else if (devWorkShopMenuPath == "") Debug.LogError("devWorkShopMenuPath must be set");
    else if (returnToMenuButton == "") Debug.LogError("returnToMenuButton must be set");
    else if (infoTextMeshPro == null) Debug.LogError("infoTextMeshPro must be set", infoTextMeshPro);
    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function setUpChecker() has ended");
  }

  // -----------------------------------------
  // File processing function
  // -----------------------------------------

  public void fileMain(string[] args)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function fileMain() has started");

    // -----------------------------------------

    foreach(string path in args)
    {
        if(checkIfMeta(path))
        {
            // This path is a SceneName.unity.meta file
            continue;
        }
        else if(File.Exists(path))
        {
              // This path is a file
              ProcessFile(path);
        }
        else if(Directory.Exists(path))
        {
              // This path is a directory
              ProcessDirectory(path);
        }
        else
        {
            Debug.Log(path + "is not a valid file or directory.");
        }
    }

    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function fileMain() has ended");
  }

  public void ProcessFile(string path)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function ProcessFile() has started");

    // -----------------------------------------

    // will add file to scenePaths list
    scenePaths.Add(path);

    // debugging
    if (listsBeingUpdated) Debug.Log ("Added to scenePaths: " + path);

    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function ProcessFile() has ended");
  }

  public void ProcessDirectory(string targetDirectory)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function ProcessDirectory() has started");

    // -----------------------------------------

    // Grabs all directoris with in the given directory
    string[] _projectPaths = Directory.GetDirectories(targetDirectory);
    foreach(string subdirectory in _projectPaths)
    {
        // adds the directory to the projectPaths list
        projectPaths.Add(subdirectory);

        // debugging
        if (listsBeingUpdated) Debug.Log ("Added to projectPaths: " + subdirectory);
    }

    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function ProcessDirectory() has ended");
  }

  public bool checkIfMeta (string path)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function checkIfMeta() has started");

    // -----------------------------------------

    // will check to see if the file is a .meta file
    if (path.Contains(".meta"))
    {
      // debuging
      if(fileBeingProcessed) Debug.Log("Found meta file: " + path);

      return true;
    }
    else
    {
      return false;
    }

    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function checkIfMeta() has ended");
  }

  // -----------------------------------------
  // Button generating functions
  // -----------------------------------------

  public void UpdateUIProjectButtons()
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function UpdateUIProjectButtons() has started");

    // -----------------------------------------

    // -----------------------------------------
    // clear old list and old buttons
    // -----------------------------------------
    projectPaths.Clear();
    destroyChildren (projectButtonsParent.transform);

    // debuging
    if (listsBeingUpdated) Debug.Log ("projectPaths was cleared");

    // -----------------------------------------
    // generat project paths
    // -----------------------------------------
    fileMain (paths);

    // -----------------------------------------
    // instatiate buttons
    // -----------------------------------------
    int y = 0;
    foreach(string projectPath in projectPaths)
    {
      // Instantiate button
      GameObject projectButton = Instantiate(projectButtonsPreFab, projectButtonsPosStart, Quaternion.identity, projectButtonsParent.transform);

      // Set button position
      Vector3 projectButtonsPos = projectButtonsPosStart;
      projectButtonsPos.y += y * projectButtonsPosOffsetY;
      projectButton.transform.localPosition = projectButtonsPos;
      y++;

      // Set button text
      string buttonText = projectPath.Replace(paths[0], "").Replace("/","");
      projectButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;

      //Add button event listener
      projectButton.GetComponent<Button>().onClick.AddListener(() => UpdateUISceneButtons(projectPath));
      projectButton.GetComponent<Button>().onClick.AddListener(() => projectsMenu.SetActive(false));
      projectButton.GetComponent<Button>().onClick.AddListener(() => projectsScenesMenu.SetActive(true));
    }

    // -----------------------------------------
    // make back button
    // -----------------------------------------
    GameObject backButton = Instantiate(projectButtonsPreFab, projectButtonsPosStart, Quaternion.identity, projectButtonsParent.transform);

    // Set button position
    Vector3 backButtonPos = projectButtonsPosStart;
    backButtonPos.y += y * projectButtonsPosOffsetY;
    backButton.transform.localPosition = backButtonPos;
    y++;

    // Set button text
    backButton.GetComponentInChildren<TextMeshProUGUI>().text = "back";

    //Add button event listener
    backButton.GetComponent<Button>().onClick.AddListener(() => projectsMenu.SetActive(false));
    backButton.GetComponent<Button>().onClick.AddListener(() => mainMenu.SetActive(true));

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function UpdateUIProjectButtons() has ended");
  }

  public void UpdateUISceneButtons(string projectFile)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function UpdateUISceneButtons() has started");

    // -----------------------------------------
    // clear old list and old buttons
    // -----------------------------------------
    scenePaths.Clear();
    destroyChildren (sceneButtonsParent.transform);

    Debug.Log("UpdateUISceneButtons(" + projectFile + ") was called");

    // -----------------------------------------
    // generate scene paths
    // -----------------------------------------
    string scenesDirectory = projectFile + "/Scenes";
    string[] _scenePaths = Directory.GetFiles(scenesDirectory);

    fileMain(_scenePaths);

    // -----------------------------------------
    // instatiate buttons
    // -----------------------------------------
    int y = 0;
    foreach(string scene in scenePaths)
    {
      // Instantiate button
      GameObject projectButton = Instantiate(projectButtonsPreFab, projectButtonsPosStart, Quaternion.identity, sceneButtonsParent.transform);

      // Set button position
      Vector3 projectButtonsPos = projectButtonsPosStart;
      projectButtonsPos.y += y * projectButtonsPosOffsetY;
      projectButton.transform.localPosition = projectButtonsPos;
      y++;

      // Set button text
      string buttonText = scene.Replace(scenesDirectory, "").Replace(".unity", "").Replace("/","");
      projectButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;

      //Add button event listener
      projectButton.GetComponent<Button>().onClick.AddListener(() => onClickScene(scene));
    }

    // -----------------------------------------
    // make back button
    // -----------------------------------------
    GameObject backButton = Instantiate(projectButtonsPreFab, projectButtonsPosStart, Quaternion.identity, sceneButtonsParent.transform);

    // Set button position
    Vector3 backButtonPos = projectButtonsPosStart;
    backButtonPos.y += y * projectButtonsPosOffsetY;
    backButton.transform.localPosition = backButtonPos;
    y++;

    // Set button text
    backButton.GetComponentInChildren<TextMeshProUGUI>().text = "back";

    //Add button event listener
    backButton.GetComponent<Button>().onClick.AddListener(() => projectsScenesMenu.SetActive(false));
    backButton.GetComponent<Button>().onClick.AddListener(() => projectsMenu.SetActive(true));

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function UpdateUISceneButtons() has ended");
  }

  public void destroyChildren (Transform parent)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function destroyChildren() has started");

    foreach (Transform child in parent)
    {
      Destroy(child.gameObject);
    }

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function destroyChildren() has ended");
  }

  // -----------------------------------------
  // on button click or input functions
  // -----------------------------------------

  public void returnToWorkShopMenu(string path)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function returnToWorkShopMenu() has started");

    onClickScene(path);
    Cursor.lockState = CursorLockMode.None;
    Destroy(gameObject);

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function returnToWorkShopMenu() has ende");
  }

  public void onClickScene(string scene)
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function onClickScene() has started");

    // -----------------------------------------

    SceneManager.LoadScene(scene);

    // debugging
    if (fileBeingProcessed) Debug.Log (scene + " was loaded");

    // -----------------------------------------

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function onClickScene() has ended");
  }

  public void onClickQuit()
  {
    // debugging
    if (functionStartAndEnding) Debug.Log ("Function onClickQuit() has started");

    Application.Quit();

    // debugging
    if (functionStartAndEnding) Debug.Log ("Function onClickQuit() has ended");
  }
}

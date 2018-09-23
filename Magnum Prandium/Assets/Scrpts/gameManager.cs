using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;
    public static GameObject globalDataObject = null;
    List<string> openScenes = new List<string>();

    private void Awake()
    {
        Debug.Assert(gameManager == null, "There should only be one game manager in the game!, found: " + gameManager + " Expected: null");
        gameManager = this;
    }
    private void OnDestroy()
    {
        Debug.Assert(gameManager == this, "There should only be one game manager in the game!, found: " + gameManager + " Expected: "+this );
        gameManager = null;
    }

    private void Start()
    {
        globalDataObject = GameObject.Find("globalDataObject");



        //start game
        switchScene("WeaponsTesting");
    }

    void switchScene(string targetScene)
    {
        foreach (string sceneName in openScenes)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        openScenes.Add(targetScene);
        SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
    }

    void switchScene(List<string> targetScene)
    {
        foreach (string sceneName in openScenes)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        foreach (string sceneName in targetScene)
        {
            openScenes.Add(sceneName);
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}

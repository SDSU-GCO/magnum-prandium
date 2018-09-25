using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitcher
{
    static List<string> openScenes = new List<string>();

    

    public static void switchScene(string targetScene)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("NeverUnload"));
        foreach (string sceneName in openScenes)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        openScenes.Add(targetScene);
        SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
    }

    public static void switchScene(List<string> targetScene)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("NeverUnload"));
        foreach (string sceneName in openScenes)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        foreach (string sceneName in targetScene)
        {
            openScenes.Add(sceneName);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
    
}

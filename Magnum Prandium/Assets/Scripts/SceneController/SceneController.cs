using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public static SceneController sceneController = null;
    public static GameObject sceneData = null;

    private void Awake()
    {
        Debug.Assert(sceneController == null, "There should only be one scene logic in the scene!, found: " + sceneController + " Expected: null");
        sceneController = this;
    }

    void OnDestroy()
    {
        Debug.Assert(sceneController == this, "There should only be one scene logic in the scene!, found: " + sceneController + " Expected: " + this);
        sceneController = null;
    }

}

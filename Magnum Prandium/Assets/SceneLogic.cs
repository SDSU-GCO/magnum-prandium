﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLogic : MonoBehaviour {

    public static SceneLogic sceneLogic = null;
    public static GameObject sceneData = null;

    private void Awake()
    {
        Debug.Assert(sceneLogic == null, "There should only be one scene logic in the scene!, found: " + sceneLogic + " Expected: null");
        sceneLogic = this;
    }

    void OnDestroy()
    {
        Debug.Assert(sceneLogic == this, "There should only be one scene logic in the scene!, found: " + sceneLogic + " Expected: " + this);
        sceneLogic = null;
    }
}

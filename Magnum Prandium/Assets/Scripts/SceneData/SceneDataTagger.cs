﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataTagger : MonoBehaviour {
    
    private void Awake()
    {
        Debug.Assert(SceneController.sceneData == null, "There should only be one scene data in the scene!, found: " + SceneController.sceneData + " Expected: null");
        SceneController.sceneData = gameObject;
    }

    private void OnDestroy()
    {
        Debug.Assert(SceneController.sceneData == gameObject, "There should only be one scene data in the scene!, found: " + SceneController.sceneData + " Expected: " + gameObject);
        if(SceneController.sceneData==gameObject)
        {
            SceneController.sceneData = null;
        }
    }
}

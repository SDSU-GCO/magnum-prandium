using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSupervisor : MonoBehaviour {

    public static SceneSupervisor sceneSupervisor = null;
    public static GameObject sceneData = null;

    private void Awake()
    {
        Debug.Assert(sceneSupervisor == null, "There should only be one scene logic in the scene!, found: " + sceneSupervisor + " Expected: null");
        sceneSupervisor = this;
    }

    void OnDestroy()
    {
        Debug.Assert(sceneSupervisor == this, "There should only be one scene logic in the scene!, found: " + sceneSupervisor + " Expected: " + this);
        sceneSupervisor = null;
    }

}

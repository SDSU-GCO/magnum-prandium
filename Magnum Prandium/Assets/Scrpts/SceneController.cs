using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public static SceneController sceneLogic = null;
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

    private void Update()
    {
        if(sceneData.GetComponent<PlayerData>().HP <= 0)
        {
            Debug.Log("Player ded");
        }
        if(sceneData.GetComponent<EnemyData>().enemyCount<=0)
        {
            Debug.Log("Congrats on killing all the badies!  You win!");
        }
    }
}

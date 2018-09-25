using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSceneTaggerSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.SetActiveScene(gameObject.scene);
    }
}

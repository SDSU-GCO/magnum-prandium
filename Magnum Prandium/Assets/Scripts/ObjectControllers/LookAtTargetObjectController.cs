using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetObjectController : MonoBehaviour {

    private GameObject target;
    
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Protagonist");
	    Debug.Assert(target != null, "Error, nothing to no target set to face in FaceObject!  Game Object: "+gameObject+" Target: "+target);
        }
	
	// Update is called once per frame
	void Update () {
		transform.up = (Vector2)(target.transform.position - transform.position);
	    }
    }

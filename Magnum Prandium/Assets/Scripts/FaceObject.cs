using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObject : MonoBehaviour {

    private GameObject target;
    
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Protagonist");
	    Debug.Assert(target != null);
        }
	
	// Update is called once per frame
	void Update () {
		transform.up = target.transform.position - transform.position;
	    }
    }

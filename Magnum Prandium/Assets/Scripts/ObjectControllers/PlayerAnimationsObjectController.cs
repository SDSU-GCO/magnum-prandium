using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsObjectController : MonoBehaviour {

    Animator animator;
    public float T = 0.01F;

	// Use this for initialization
	void Start(){
		animator = GetComponent<Animator>();
	    }
	
	// Update is called once per frame
	void Update(){
		float H = Input.GetAxis("Horizontal");
		float V = Input.GetAxis("Vertical");
        //bool  S = Input.GetButtonDown("Shoot");
        bool  I = (H < T && H > -T);

        animator.SetFloat("HA", H);
        animator.SetFloat("VA", V);
        animator.SetBool("Idle", I);
	    }
    }

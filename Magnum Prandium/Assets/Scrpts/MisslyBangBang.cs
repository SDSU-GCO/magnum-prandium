using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MisslyBangBang : MonoBehaviour {

    [SerializeField]
    float lifetimeInSeconds=10;

    
    // Update is called once per frame
    void Update ()
    {
        lifetimeInSeconds = Mathf.Max(0, lifetimeInSeconds - Time.deltaTime);
        if(lifetimeInSeconds<=0)
        {
            GameObject.Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy"))
        {
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);
        }
    }
}

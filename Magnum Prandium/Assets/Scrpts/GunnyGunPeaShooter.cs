using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunnyGunPeaShooter : MonoBehaviour
{

    [SerializeField]
    GameObject misslePrefab = null;
    [SerializeField]
    float missleSpeed = 1;
    float coolDownMissle = 0;
    [SerializeField]
    float coolDownMissleDefault = 0.25f;

    private void OnEnable()
    {
        coolDownMissleDefault = coolDownMissle;
    }
    

    // Update is called once per frame
    void Update()
    {
        coolDownMissle = Mathf.Max(0, coolDownMissle - Time.deltaTime);
        if (UnityEngine.Input.GetButtonDown("missleAttack"))
        {
            missleAttack();
        }
    }

    public void missleAttack()
    {
        if (coolDownMissle <= 0)
        {
            coolDownMissle = coolDownMissleDefault;
            Vector2 attackAngle = transform.up;
            GameObject missle = Instantiate(misslePrefab, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
            missle.GetComponent<Rigidbody2D>().velocity = new Vector2(attackAngle.x * missleSpeed, attackAngle.y * missleSpeed);
        }
    }
}

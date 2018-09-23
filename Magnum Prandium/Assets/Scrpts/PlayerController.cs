using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    float dashCoolDown = 0;
    Vector2 dashBonusSpeed;
    [SerializeField]
    float dashCoolDownDefault = 2;
    [SerializeField]
    float dashMultiplier = 2.5f;
    [SerializeField]
    float RotationSpeed = 1;
    [SerializeField]
    float ForwardSpeed = 1;
    Rigidbody2D RigidbodyRef;
    
    public void takeDamage(int damage)
    {
        GameManager.globalDataObject.GetComponent<PlayerData>().HP -= damage;
    }

    void Start()
    {
        RigidbodyRef = GetComponent<Rigidbody2D>();
        Debug.Assert(RigidbodyRef != null);
    }

    void Update()
    {

        //Check for inputs
        //Add velocity to the front of the object.

        float RotationInput = -1 * Input.GetAxis("Horizontal");
        float ForwardInput = Input.GetAxis("Vertical");

        gameObject.transform.rotation *= Quaternion.AngleAxis(RotationSpeed * RotationInput, new Vector3(0, 0, 1));
        RigidbodyRef.velocity = transform.up * ForwardSpeed * ForwardInput;
        

        if (Input.GetButtonDown("Dash") && dashCoolDown <= 0)
        {
            dashBonusSpeed = RigidbodyRef.velocity * (dashMultiplier - 1);
            dashCoolDown = dashCoolDownDefault;
        }

        if(dashCoolDown>0)
        {
            RigidbodyRef.velocity += dashBonusSpeed * ((dashCoolDown) / dashCoolDownDefault);
        }

        dashCoolDown = Mathf.Max(0, dashCoolDown - Time.deltaTime);

    }
}
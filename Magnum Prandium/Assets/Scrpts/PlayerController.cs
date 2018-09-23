using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float RotationSpeed = 1;
    public float ForwardSpeed = 1;
    Rigidbody2D RigidbodyRef;

    public int HP = 3;
    public void takeDamage(int damage)
    {
        HP -= damage;
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

        if (HP <= 0)
        {
            Debug.Log("Player ded");
        }

    }
}
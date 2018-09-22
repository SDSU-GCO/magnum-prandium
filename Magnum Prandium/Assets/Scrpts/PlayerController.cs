using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{

<<<<<<< HEAD
    public float RotationSpeed = 1;
    public float ForwardSpeed  = 1;
    
=======
    public float speed=1;
    public float moveHorizontal;
    public float  moveVertical;
>>>>>>> 35aa000aeba858c0602deb35c1696a92a5c06720

    Rigidbody2D RigidbodyRef;

    void Start(){                
        RigidbodyRef = GetComponent<Rigidbody2D>();
        Debug.Assert(RigidbodyRef != null);
        }

<<<<<<< HEAD
    void Update(){
        
        //Check for inputs
        //Add velocity to the front of the object.

        float RotationInput = -1 * Input.GetAxis("Horizontal");
        float ForwardInput  = Input.GetAxis("Vertical");
        
        gameObject.transform.rotation *= Quaternion.AngleAxis(RotationSpeed * RotationInput, new Vector3(0, 0, 1));
        RigidbodyRef.velocity = transform.up * ForwardSpeed * ForwardInput;
        
        }
    }
=======
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal * speed * Time.deltaTime, Time.deltaTime * moveVertical * speed);

        rb.velocity = movement;
    }
}
>>>>>>> 35aa000aeba858c0602deb35c1696a92a5c06720

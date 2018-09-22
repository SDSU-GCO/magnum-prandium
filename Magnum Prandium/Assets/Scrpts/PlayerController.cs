using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class PlayerController : MonoBehaviour
{
    public int HP = 3;
    public float speed=1;
    public float moveHorizontal;
    public float  moveVertical;
=======
public class PlayerController : MonoBehaviour{

    public float RotationSpeed = 1;
    public float ForwardSpeed  = 1;
    
>>>>>>> d83ed02801a87d8d62bbb5e10b5e6e6c2a9173c6

    Rigidbody2D RigidbodyRef;

<<<<<<< HEAD
    public void takeDamage(int damage)
    {
        HP -= damage;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
=======
    void Start(){                
        RigidbodyRef = GetComponent<Rigidbody2D>();
        Debug.Assert(RigidbodyRef != null);
        }
>>>>>>> d83ed02801a87d8d62bbb5e10b5e6e6c2a9173c6

    void Update(){
        
        //Check for inputs
        //Add velocity to the front of the object.

<<<<<<< HEAD
        Vector2 movement = new Vector2(moveHorizontal * speed * Time.deltaTime, Time.deltaTime * moveVertical * speed);

        rb.velocity = movement;

        if(HP<=0)
        {
            Debug.Log("Player died!");
        }
    }
}
=======
        float RotationInput = -1 * Input.GetAxis("Horizontal");
        float ForwardInput  = Input.GetAxis("Vertical");
        
        gameObject.transform.rotation *= Quaternion.AngleAxis(RotationSpeed * RotationInput, new Vector3(0, 0, 1));
        RigidbodyRef.velocity = transform.up * ForwardSpeed * ForwardInput;
        
        }
    }
>>>>>>> d83ed02801a87d8d62bbb5e10b5e6e6c2a9173c6

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed=1;
    public float moveHorizontal;
    public float  moveVertical;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal * speed * Time.deltaTime, Time.deltaTime * moveVertical * speed);

        rb.velocity = movement;
    }
}
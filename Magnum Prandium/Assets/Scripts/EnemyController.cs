using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    float speed = 2;
    GameObject prey = null;
    new Rigidbody2D rigidbody2D = null;
    EnemyData enemyData = null;

    private void Start()
    {
        enemyData = SceneController.sceneData.GetComponent<EnemyData>();
        enemyData.enemyCount++;
        prey = GameObject.FindGameObjectWithTag("Protagonist");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        enemyData.enemyCount--;
    }

    // Update is called once per frame
    void Update ()
    {
        Vector2 temp = new Vector2(prey.transform.position.x - transform.position.x, prey.transform.position.y - transform.position.y);
        rigidbody2D.velocity = new Vector2(temp.normalized.x * speed, temp.normalized.y * speed);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().takeDamage(1);
            GameObject.Destroy(gameObject);
        }
    }

}

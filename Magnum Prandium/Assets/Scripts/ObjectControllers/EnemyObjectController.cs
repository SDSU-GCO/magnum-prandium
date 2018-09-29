using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectController : MonoBehaviour {

    [SerializeField]
    float speed = 2;
    new Rigidbody2D rigidbody2D = null;
    EnemyData enemyData = null;
    PreyData preyData = null;
    GameObject prey = null;

    private void Start()
    {

        enemyData = SceneSupervisor.sceneData.GetComponent<EnemyData>();
        Debug.Assert(enemyData != null, "Error, enemyData appears to be null please make sure a enemyData component is on the SceneData gameObject! debug info:\nsceneData: " + SceneSupervisor.sceneData + "\nthis: " + this + "\ngameObject: " + gameObject);
        enemyData.enemyCount++;

        rigidbody2D = GetComponent<Rigidbody2D>();
        
        #region setPrey()
        preyData = SceneSupervisor.sceneData.GetComponent<PreyData>();
        Debug.Assert(preyData != null, "Error, preyData appears to be null please make sure a PreyData component is on the SceneData gameObject! debug info:\nsceneData: " + SceneSupervisor.sceneData + "\nthis: " + this + "\ngameObject: " + gameObject);

        float? distanceToNearestPrey = null;
        foreach (GameObject possiblePrey in preyData.preyList)
        {
            float possiblePreyDistance = Vector2.Distance(possiblePrey.transform.position, transform.position);
            if(distanceToNearestPrey==null || possiblePreyDistance<distanceToNearestPrey)
            {
                prey = possiblePrey;
                distanceToNearestPrey = possiblePreyDistance;
            }
        }
        #endregion

    }

    private void OnDestroy()
    {
        enemyData.enemyCount--;
    }


    // Update is called once per frame
    void Update ()
    {
        //construct a positional defference vector to the prey target, convert it to 2d, and normalize it to get a directional vector pointing toward prey
        Vector2 directionalVector = ((Vector2)(prey.transform.position - transform.position)).normalized;
        //set the velocity in the direction of the player and move at a magnitude of speed
        rigidbody2D.velocity = directionalVector * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Player"))//if we collided with player
        {
            collision.gameObject.GetComponent<PlayerObjectController>().takeDamage(1);//injure player
            ShakyShakeEarthquakeObjectController shakyShakeEarthquakeObjectController = SceneSupervisor.sceneSupervisor.GetComponentInChildren<ShakyShakeEarthquakeObjectController>();
            if (shakyShakeEarthquakeObjectController != null)
            {
                shakyShakeEarthquakeObjectController.rockTheBoat();
            }

            GameObject.Destroy(gameObject);//selfdestruct
        }
    }

}

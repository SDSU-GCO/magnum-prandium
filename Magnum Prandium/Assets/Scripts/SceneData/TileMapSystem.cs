using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileMapSystem : MonoBehaviour {
    
    
    Tilemap tilemap;

    // Use this for initialization
    void Start () {
        Tile.ColliderType colliderType = tilemap.GetColliderType(new Vector3Int(0,0,0));
        tilemap.GetBoundsLocal(new Vector3Int(0, 0, 0));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

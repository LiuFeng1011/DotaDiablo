using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector2 GetWorldPos(Vector2 mappos){
        float x = mappos.x + mappos.y;
        float y = -mappos.x / 2f + mappos.y / 2f;

        Vector2 worldpos = new Vector2(x,y);
        return worldpos;
    }

    public Vector2 GetMapPos(Vector2 worldpos)
    {
        float x = worldpos.x / 2f - worldpos.y;
        float y = worldpos.x - x;

        Vector2 mappos = new Vector2(x, y);
        return mappos;
    }
}

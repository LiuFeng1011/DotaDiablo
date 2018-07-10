using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpriteTest : MonoBehaviour {

    public SpriteRenderer sr;

	// Use this for initialization
	void Start () {

        Sprite[] sprites;
        sprites = Resources.LoadAll<Sprite>("Texture/Map/grass-ipadhd");
        sr.sprite = sprites[3];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

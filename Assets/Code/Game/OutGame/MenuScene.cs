using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour {
    public GameObject startBtn;
	// Use this for initialization
	void Start () {
        GameUIEventListener.Get(startBtn).onClick = StartCB;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartCB(GameObject go){
        (new EventChangeScene(GameSceneManager.SceneTag.Game)).Send();
    }
}

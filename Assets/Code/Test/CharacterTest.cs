using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTest : MonoBehaviour {

    public GameObject[] btns;
    public Animator Animator;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < btns.Length;  i++){
            GameUIEventListener.Get(btns[i]).onClick = BtnCB;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BtnCB(GameObject go){
        Animator.SetTrigger("LoopAll");
        Animator.Play(go.name);
    }
}

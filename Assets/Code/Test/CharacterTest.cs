using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTest : MonoBehaviour {

    public GameObject[] btns;
    public Animator animator;

    string lastAnimatorName = "";
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

        animator.SetBool(lastAnimatorName, false);
        animator.SetBool(go.name, true);
        lastAnimatorName = go.name;
    }
}

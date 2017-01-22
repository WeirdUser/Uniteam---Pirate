using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator: MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //anim.SetBool("IsMoving", false);
        //anim.SetBool("IsWorking", false);
        //anim.SetBool("IsBracing", false);
        //anim.SetTrigger("IsDead");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownDoorScript : MonoBehaviour {

    public Transform exit;
    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerStay(Collider objectTouched)
    {
        Rigidbody playerBody = objectTouched.gameObject.GetComponent<Rigidbody>();

        if (Input.GetAxis("Vertical") > 0)
        {
            playerBody.position = exit.position;

            exit.gameObject.GetComponent<DownDoorScript>().enabled = false;
        }
    }
}

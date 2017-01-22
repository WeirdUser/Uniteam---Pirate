using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownDoorScript : MonoBehaviour {

    public Transform exit;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerStay(Collider objectTouched)
    {
        Rigidbody playerBody = objectTouched.gameObject.GetComponent<Rigidbody>();

        if (Input.GetAxis(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow") > 0) // Input.GetButtonDown(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow")) &&
        {
            playerBody.position = exit.position;
        }
    }
}

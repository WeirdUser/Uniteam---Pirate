using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDoorScript : MonoBehaviour {

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
            playerBody.position.Set(playerBody.position.x, playerBody.position.y + 2.0f, playerBody.position.z);
        }
    }
}

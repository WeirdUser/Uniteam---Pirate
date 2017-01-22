using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownDoorScript : MonoBehaviour {

    public Transform exit;
    private float timer;
    private bool axisInUse;

	// Use this for initialization
	void Start () {
        axisInUse = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerStay(Collider objectTouched)
    {
        Rigidbody playerBody = objectTouched.gameObject.GetComponent<Rigidbody>();

        if (Input.GetAxisRaw(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow") > 0) // Input.GetButtonDown(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow")) &&
        {
            if (!axisInUse)
            {
                playerBody.position = exit.position;
                axisInUse = true;
            }
        }
        if(Input.GetAxisRaw(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow") == 0)
        {
            axisInUse = false;
        }
    }
}

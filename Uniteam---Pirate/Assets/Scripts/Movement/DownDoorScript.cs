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
        if (Input.GetAxis(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow") > 0) // Input.GetButtonDown(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow")) &&
        {
            objectTouched.gameObject.transform.position = exit.position;
        }
    }
}

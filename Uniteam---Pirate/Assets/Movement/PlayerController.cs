using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerBody;
    private float speed = 3.0f;

	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);

        playerBody.AddForce(movement * speed);
        
        /*
        var x = Input.GetAxis("Horizontal") * Time.deltaTime;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        
        transform.Translate(x, 0, 0);
        //transform.Translate(0, 0, z);
        */
    }
}

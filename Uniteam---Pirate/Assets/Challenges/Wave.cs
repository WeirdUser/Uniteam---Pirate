using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private bool active;
    private Rigidbody waveBody;
    public float speed;

	// Use this for initialization
	void Start () {

        waveBody = GetComponent<Rigidbody>();
        active = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f);

            waveBody.AddForce(movement * speed);

            if(waveBody.position.z <= -15.0f)
            {
                active = false;

                waveBody.velocity = Vector3.zero;
                waveBody.position = new Vector3(-1.0f, 0.0f, 5.0f);
            }
        }

	}

    public void activate()
    {
        active = true;
    }
}

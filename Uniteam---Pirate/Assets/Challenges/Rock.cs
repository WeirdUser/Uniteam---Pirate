using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private bool active;
    private bool passed;
    private Rigidbody rockBody;
    public float speed;
    public boat ship;

	// Use this for initialization
	void Start () {

        rockBody = GetComponent<Rigidbody>();
        active = true;
        passed = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
            Vector3 movement;
            if (!passed)
            {
                movement = new Vector3(0.0f, 0.0f, -1.0f);
                ship.damageHull();
            } else
            {
                movement = new Vector3(0.5f, 0.0f, -1.0f);
            }
            rockBody.AddForce(movement * speed);

            if (rockBody.position.z <= -15.0f)
            {
                active = false;

                rockBody.velocity = Vector3.zero;
                rockBody.position = new Vector3(22.43f, -3.78f, 16.22f);
            }
        }

    }

<<<<<<< HEAD
    public void activate(bool driverPassed)
    {
        active = true;
        gameObject.SetActive(true);
        this.passed = driverPassed;
    }
}

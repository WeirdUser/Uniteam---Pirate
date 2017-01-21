using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : Challenge {

    private bool active = false;
    private Rigidbody waveBody;
    private float speed;

	// Use this for initialization
	void Start () {

        waveBody = GetComponent<Rigidbody>();
        speed = 6.0f;
         
    }
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);

            waveBody.AddForce(movement * speed);
        }

	}

    void OnCollisionEnter(Collision impact)
    {
        if (impact.gameObject.CompareTag("Player"))
        {
            impact.gameObject.GetComponent<CharacterController>().enabled = false;

            StartCoroutine(Wait(5.0f));

            impact.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }
}

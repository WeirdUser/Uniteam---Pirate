using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private bool active;
    private Rigidbody waveBody;
    public float speed;
    private AudioSource _audioSource;

	// Use this for initialization
	void Start () {

        waveBody = GetComponent<Rigidbody>();
        active = true;
        _audioSource = GetComponent<AudioSource>();

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
                waveBody.position = new Vector3(-29.1f, -4.52f, 15.5f);
            }
        }

	}

    public void activate()
    {
        active = true;
        AudioClip wave = Resources.Load("Sounds/Waves_0" + Random.Range(1, 5)) as AudioClip;
        _audioSource.PlayOneShot(wave, 1f);
        gameObject.SetActive(true);
    }
}

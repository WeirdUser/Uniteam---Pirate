using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public LookOut lookout;
    public Rock rock;
    private float timerToRock;
    private float stationTimer;
    private bool active;
    private bool isInUse;
    private bool driverResult;
    private float speed;

    // Use this for initialization
    void Start () {
        driverResult = false;
        stationTimer = 50.0f;
        timerToRock = 50.0f;
        speed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (active)
        {/*
            if (lookout.passed)
            {
                stationTimer *= 2;
            }
            */
            if (this.isInUse)
            {
                stationTimer -= Time.deltaTime * (speed * 2);

                if(stationTimer <= 0.0f)
                {
                    driverResult = true;
                    this.isInUse = false;
                }
            }

            timerToRock -= Time.deltaTime * speed;

            if(timerToRock <= 0.0f)
            {
                rock.activate(driverResult);
                setActive(false);
            }
        }

	}

    public void setActive(bool value)
    {
        active = value;
    }

    void OnTriggerStay(Collider objectTouched)
    {
        PlayerController player = objectTouched.GetComponent<PlayerController>();

        if (stationTimer <= 0.0f)
        {
            player.setIsOccupied(false);
        }

        if (Input.GetAxisRaw(player.playerName + "_VerticalArrow") > 0.0f) // Input.GetButtonDown(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow")) &&
        {
            player.setIsOccupied(true);
            //player.stopPlayer();
            this.isInUse = true;
        }
        else if (Input.GetAxisRaw(player.playerName + "_VerticalArrow") < 0.0f)
        {
            player.setIsOccupied(false);
            this.isInUse = false;
        }
    }
}

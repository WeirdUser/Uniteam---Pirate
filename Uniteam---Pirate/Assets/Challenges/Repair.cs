using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour {

    private float stationTimer;
    private float speed;
    private bool active;
    private bool isInUse;
    private boat ship;
    private GameObject hull;

    // Use this for initialization
    void Start()
    {
        stationTimer = 50.0f;
        speed = 5.0f;
        active = false;
        isInUse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (this.isInUse)
            {
                stationTimer -= Time.deltaTime * speed;

                if (stationTimer <= 0.0f)
                {
                    ship.repairHull(this.hull);

                    this.isInUse = false;
                    setActive(false);
                }
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

        if (Input.GetAxisRaw(player.playerName + "_VerticalArrow") > 0.0f && !this.isInUse) // Input.GetButtonDown(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow")) &&
        {
            player.setIsOccupied(true);
            player.stopPlayer();
            this.isInUse = true;
        }
        else if (Input.GetAxisRaw(player.playerName + "_VerticalArrow") < 0.0f)
        {
            player.setIsOccupied(false);
            this.isInUse = false;
        }
    }
}

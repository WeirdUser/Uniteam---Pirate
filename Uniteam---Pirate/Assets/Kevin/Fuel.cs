using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Challenge {

    private float fuelPercent;
    private bool alarmHasPlayed;
    private bool axisInUse;
    private string playerName;

	// Use this for initialization
	void Start () {
        fuelPercent = 100.0f;
        alarmHasPlayed = false;
	}
	
	// Update is called once per frame
	void Update () {

        fuelPercent -= Time.deltaTime * 2;

        if(fuelPercent < 30 && !alarmHasPlayed)
        {
            playAlarm();
            alarmHasPlayed = true;

        }
    }

    void playAlarm()
    {
        //Play alarm sound here.
        print(fuelPercent);
    }

    void refuel()
    {
        bool square = true;
        bool circle = false;
        while (fuelPercent < 100.0f)
        {
            if (square)
            {
                showButton("Square");
            } else
            {
                showButton("Circle");
            }


            if((Input.GetButtonDown(playerName + "_Square") && square)
                || (Input.GetButtonDown(playerName + "_Circle") && circle))
            {
                fuelPercent += 5.0f;
                print(fuelPercent);
                square = !square;
                circle = !circle;
            }

        }
    }

    public void showButton(string nextButton)
    {
        print(nextButton);
        transform.Find("QuickEvent").Find(nextButton).gameObject.SetActive(true);

        if (nextButton.Equals("Square"))
        {
            transform.Find("QuickEvent").Find("Circle").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("QuickEvent").Find("Square").gameObject.SetActive(false);
        }
    }

    void OnTriggerStay(Collider objectTouched)
    {
        playerName = objectTouched.GetComponent<PlayerController>().playerName;

        if (Input.GetAxisRaw(playerName + "_VerticalArrow") > 0) // Input.GetButtonDown(objectTouched.GetComponent<PlayerController>().playerName + "_VerticalArrow")) &&
        {
            if (!axisInUse)
            {
                refuel();
                axisInUse = true;
            }
        }
        if (Input.GetAxisRaw(playerName + "_VerticalArrow") == 0)
        {
            axisInUse = false;
        }
    }
}

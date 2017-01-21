using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOut : Challenge {

	private string buttonToPress = "";

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(timerIsStarted){
			reactionTime -= Time.deltaTime;
			if(reactionTime <= 0.0f){
				//print("Failed!");
				reactionTime = 2.0f;
				timerIsStarted = false;
				transform.Find("QuickEvent").Find(buttonToPress).gameObject.SetActive(false);
				startChallenge();
			}
		}
	}

    public override void waitForPlayer()
    {
        _waitForPlayer = true;
    }

	public override void startChallenge(){
		print("it's a GO! for LookOut");
		buttonToPress = quickEventButton[Random.Range(0,quickEventButton.Length)];

		showButton(buttonToPress);
		timerIsStarted = true;
	}

	public void showButton(string buttonToPress){
		print(buttonToPress);
		transform.Find("QuickEvent").Find(buttonToPress).gameObject.SetActive(true);
	}

    public void buttonPressed(string buttonPressed)
    {
        if (buttonPressed == buttonToPress)
        {
            reactionTime = 2.0f;
            transform.Find("QuickEvent").Find(buttonToPress).gameObject.SetActive(false);
            startChallenge();
        }
        else
        {
            //print("Failed!");
            timerIsStarted = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOut : Challenge {

	// Use this for initialization
	void Start () {
		startChallenge();
	}
	
	// Update is called once per frame
	void Update () {
		if(timerIsStarted){
			reactionTime -= Time.deltaTime;
			if(reactionTime <= 0.0f){
				startChallenge();
				reactionTime = 2.0f;
				timerIsStarted = false;
			}
		}
		
	}
	public override void startChallenge(){
		print("it's a GO! for LookOut");
		string buttonToPress = quickEventButton[Random.Range(0,quickEventButton.Length)];

		showButton(buttonToPress);
		timerIsStarted = true;
	}

	public void showButton(string buttonToPress){
		print(buttonToPress);
		transform.Find("QuickEvent").Find(buttonToPress).gameObject.SetActive(true);
	}

}

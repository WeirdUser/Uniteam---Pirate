using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour {

	protected string[]  quickEventButton = {"XButton","Triangle","Square","Circle"};
	protected float reactionTime = 2.0f;
    protected GameObject _activePlayer;

	protected bool timerIsStarted = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void naming(){
		print("Je suis un Challenges");
	}
	public virtual void startChallenge(){
		//print("it's a GO!");
	}
}

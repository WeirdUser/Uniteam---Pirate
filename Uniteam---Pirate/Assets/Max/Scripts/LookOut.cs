using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOut : Challenge {

	private string buttonToPress = "";

	private bool isComming = false;

	[SerializeField] private float blinkingSpeed = 0.5f;
	private float timeBlinkingLeft;

	private bool alreadyUseStation = false;

	private string cataName = "";
	[SerializeField] private GameObject exclamation;
	[SerializeField] private GameObject waveBubble;
	[SerializeField] private GameObject rockBubble;

	// Use this for initialization
	void Start () {
        timeBlinkingLeft = blinkingSpeed;
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

		if(isComming && !alreadyUseStation) {
			timeBlinkingLeft -= Time.deltaTime;
			if(timeBlinkingLeft <= 0.0f){
				if(exclamation.active){
					exclamation.SetActive(false);
				}else {
					exclamation.SetActive(true);
				}
				timeBlinkingLeft = blinkingSpeed;
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

	public void startEvent(string catastropheName) {
		isComming = true;
		cataName = catastropheName;
	}

	void OnTriggerStay(Collider objectTouched){
		PlayerController player = objectTouched.GetComponent<PlayerController>();
		if(Input.GetAxis(player.playerName + "_VerticalArrow") > 0 && !player.getIsOccupied()){
			player.setIsOccupied(true);
			exclamation.SetActive(false);
			playerOnStation = true;
			player.stopPlayer();
			alreadyUseStation = true;
			switch (cataName){
				case "Rock":
					rockBubble.gameObject.SetActive(true);	
					StartCoroutine(waitForIt(rockBubble.gameObject));
				break;
				case "Wave":	
					waveBubble.gameObject.SetActive(true);
					StartCoroutine(waitForIt(waveBubble.gameObject));
				break;
				
			}
		} else if(player.getIsOccupied() && Input.GetAxis(player.playerName + "_VerticalArrow") > 0){
			player.setIsOccupied(false);
			playerOnStation = false;
		}


	}

	public void startQuickEvent(){

	}

	IEnumerator waitForIt(GameObject bubble) {       
		yield return new WaitForSeconds (2.0f);
 
         bubble.SetActive(false);
    }



}

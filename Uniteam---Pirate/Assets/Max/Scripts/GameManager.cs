using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField] private GameObject mainMenu;
	private bool gameStarted = false;

	 float timeLeft = 60.0f; 

	 public GameObject challenges;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (mainMenu);
	}

	// Use this for initialization
	void Start () {
		startNewChallenge();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0.0f){
			startNewChallenge();
			timeLeft = Random.Range(10,timeLeft-1);
		}
	}

	private void startNewChallenge(){
		print(challenges.transform.childCount);
		int index = Random.Range(0,challenges.transform.childCount);
		Transform newChallenge = challenges.transform.GetChild(index);

		switch (newChallenge.tag){
			case "Fornace":
				//newChallenge.GetComponent<Fornace>().naming();
				break;
		}


	}

	public void GameOver() {

	}

	public void EnterGame(){
		mainMenu.SetActive (false);
		gameStarted = true;
	}
}

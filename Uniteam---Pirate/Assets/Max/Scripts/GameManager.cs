﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private bool[] _isPlayerReady;
    private bool _challengeActive = false;

    [SerializeField] private GameObject mainMenu;

	 float timeLeft = 5.0f; 

	 public GameObject challenges;
	 bool gameStarted = false;

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
		//startNewChallenge();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameStarted && !_challengeActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {  
                startNewChallenge();
                _challengeActive = true;
                timeLeft = Random.Range(10, timeLeft - 1);
            }
        }
	}

	private void startNewChallenge(){
        print("START NEW CHALLENGE");
		print(challenges.transform.childCount);
		int index = Random.Range(0,challenges.transform.childCount);
		//Transform newChallenge = challenges.transform.GetChild(index);
        Transform newChallenge = challenges.transform.GetChild(1);
        print(newChallenge.tag);
        Challenge challengeScript;
		switch (newChallenge.tag){
			case "Fornace":
                challengeScript = newChallenge.gameObject.GetComponent<Fornace>();
                print("script challenge " + challengeScript);
                challengeScript.naming();
				break;
            case "LookOut":
                challengeScript = newChallenge.gameObject.GetComponent<LookOut>();
                print("script challenge " + challengeScript);
                challengeScript.startChallenge();
                break;
		}
	}

    public void SetCanSpawnChallenge(bool value)
    {
        _challengeActive = value;
    }

	public void GameOver() {

	}

	public void EnterGame(){
		mainMenu.SetActive (false);
		gameStarted = true;
	}




	// DE ALEX
	// SETTERS
    public void SetIsPlayerReady(bool[] value)
    {
        _isPlayerReady = value;
        for(int i = 0; i<_isPlayerReady.Length; i++)
        {
            if (_isPlayerReady[i])
            {
                print("Player " + (i + 1) + " is ready.");
            }
        }
    }

    // GETTERS
    public bool[] GetIsPlayerReady()
    {
        return _isPlayerReady;
    }
}

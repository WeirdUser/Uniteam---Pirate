using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance = null;
	private bool[] _isPlayerReady;
	
    private bool _challengeActive = false;

	private GameObject[] tblPlayers = new GameObject[4];
	[SerializeField] private GameObject player1;
	[SerializeField] private GameObject player2;
	[SerializeField] private GameObject player3;
	[SerializeField] private GameObject player4;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject wave;
    [SerializeField] private GameObject rock;

	float timeLeft = 5.0f; 

	public GameObject challenges;
    public AudioClip startSound;
    public AudioClip alerteSound;
    public AudioClip turbineSound;
    private AudioSource audioSource;
	public GameObject lookOut;
	bool gameStarted = false;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
        audioSource = GetComponent<AudioSource>();
		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (mainMenu);
		Assert.IsNotNull (player1);
		Assert.IsNotNull (player2);
		Assert.IsNotNull (player3);
		Assert.IsNotNull (player4);
	}

	// Use this for initialization
	void Start () {
		//startNewChallenge();
		tblPlayers[0] = player1;
		tblPlayers[1] = player2;
		tblPlayers[2] = player3;
		tblPlayers[3] = player4;
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
		int index = Random.Range(0,challenges.transform.childCount);
        Transform newChallenge = challenges.transform.GetChild(index);
        //lookOut.GetComponent<LookOut>().startEvent(newChallenge.tag);
        audioSource.PlayOneShot(alerteSound);

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
        audioSource.Play();
        audioSource.PlayOneShot(startSound);
        audioSource.PlayOneShot(turbineSound);
        GameObject.Find("wave").gameObject.GetComponent<Wave>().activate();
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
				tblPlayers[i].SetActive(true);
                print("Player " + (i + 1) + " is ready.");
            }
        }
    }

    // GETTERS
    public bool[] GetIsPlayerReady()
    {
        return _isPlayerReady;
    }	

	IEnumerator waitWait(GameObject bubble) {       
		yield return new WaitForSeconds (10.0f);
 
    }
}

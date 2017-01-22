using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReadyController : MonoBehaviour
{

    // Public 
    public Text _P1ConnectedText;
    public Text _P2ConnectedText;
    public Text _P3ConnectedText;
    public Text _P4ConnectedText;
    public GameObject _canvas;
    public GameObject _homeScreen;
    public MenuController _menuControllerScript;
    private int cpt = 0;
    public AudioClip _audioClip;

    public GameManager _gameManager;
    private AudioSource audioSource;
    // Private
    private bool[] _playerIsReady = new bool[4] { false, false, false, false };

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (_menuControllerScript.GetIsOpen())
        {
            bool hor = false;
            bool bx = false;
            if (Input.GetButtonDown("P1_X"))
            {
                bx = true;
            }
            if (Input.GetAxis("P1_Horizontal") < 0)
            {
                hor = true;
            }

            if(hor && bx)
            {
                cpt++;
                print(cpt);
            }

            if (Input.GetButtonDown("P1_X"))
            {
                _playerIsReady[0] = true;
                _P1ConnectedText.text = "Ready";
            }
            if (Input.GetButtonDown("P2_X"))
            {
                _playerIsReady[1] = true;
                _P2ConnectedText.text = "Ready";
            }
            if (Input.GetButtonDown("P3_X"))
            {
                _playerIsReady[2] = true;
                _P3ConnectedText.text = "Ready";
            }
            if (Input.GetButtonDown("P4_X"))
            {
                _playerIsReady[3] = true;
                _P4ConnectedText.text = "Ready";
            }

            if (Input.GetButtonDown("Cancel"))
            {
                _canvas.GetComponent<MenuManager>().ChangeMenu(_homeScreen);
            }

            if (Input.GetButtonDown("Options"))
            {
                bool canStartGame = false;
                for(int i = 0; i < _playerIsReady.Length; i++){
                    if(_playerIsReady[i]){
                        canStartGame = true;
                    }
                }
                if(canStartGame){
                    GameManager _gameManagerScript =_gameManager.gameObject.GetComponent<GameManager>(); 
                    _gameManagerScript.SetIsPlayerReady(_playerIsReady);
                    AudioSource audioSource = GetComponent<AudioSource>();
                    audioSource.PlayOneShot(_audioClip, 1f);
                    _gameManagerScript.EnterGame();
                    
                }
            }
        }
    }


    public void Init()
    {
        _playerIsReady = new bool[4] { false, false, false, false };
        Input.ResetInputAxes();
        _P1ConnectedText.text = "Press X";
        _P2ConnectedText.text = "Press X";
        _P3ConnectedText.text = "Press X";
        _P4ConnectedText.text = "Press X";
    }

    // GETTERS
    public bool[] GetPlayerIsReady()
    {
        return _playerIsReady;
    }
}

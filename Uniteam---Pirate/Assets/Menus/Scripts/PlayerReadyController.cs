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

    // Private
    private bool[] _playerIsReady = new bool[4] { false, false, false, false };

    // Update is called once per frame
    void Update()
    {
        if (_menuControllerScript.GetIsOpen())
        {
            if (Input.GetAxis("P1_X") > 0)
            {
                _playerIsReady[0] = true;
                _P1ConnectedText.text = "Ready";
            }
            if (Input.GetAxis("P2_X") > 0)
            {
                _playerIsReady[1] = true;
                _P2ConnectedText.text = "Ready";
            }
            if (Input.GetAxis("P3_X") > 0)
            {
                _playerIsReady[2] = true;
                _P3ConnectedText.text = "Ready";
            }
            if (Input.GetAxis("P4_X") > 0)
            {
                _playerIsReady[3] = true;
                _P4ConnectedText.text = "Ready";
            }

            if (Input.GetAxis("Cancel") > 0)
            {
                _canvas.GetComponent<MenuManager>().ChangeMenu(_homeScreen);
            }

            if (Input.GetAxis("Options") > 0)
            {
                MasterGameManager mgm = GameObject.Find("MasterGameManager").GetComponent<MasterGameManager>();
                mgm.SetIsPlayerReady(_playerIsReady);
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

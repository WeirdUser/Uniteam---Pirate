using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDetector : MonoBehaviour {

    // Public 
    public Text _P1ConnectedText;
    public Text _P2ConnectedText;
    public Text _P3ConnectedText;
    public Text _P4ConnectedText;

    // Private
    private bool[] _playerIsReady = new bool[4] { false, false, false, false };

    // Update is called once per frame
    void Update()
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
    } 

    // GETTERS
    public bool[] getPlayerIsReady()
    {
        return _playerIsReady;
    }
}

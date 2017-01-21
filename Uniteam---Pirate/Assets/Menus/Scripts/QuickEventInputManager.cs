using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickEventInputManager : MonoBehaviour {

    // Public
    public string _playerNumber = "P1";

    // Private
    private Dictionary<string, float> inputValue = new Dictionary<string, float>();

	// Use this for initialization
	void Start () {
        inputValue.Add("Horizontal", 0);
        inputValue.Add("Vertical", 0);
        inputValue.Add("Square", 0);
        inputValue.Add("X", 0);
        inputValue.Add("Circle", 0);
        inputValue.Add("Triangle", 0);
        inputValue.Add("L1", 0);
        inputValue.Add("L2", 0);
        inputValue.Add("R1", 0);
        inputValue.Add("R2", 0);
    }
	
	// Update is called once per frame
	void Update () {
        inputValue["Horizontal"] = Input.GetAxis(_playerNumber + "_Horizontal");
        inputValue["Vertical"] = Input.GetAxis(_playerNumber + "_Vertical");
        inputValue["Square"] = Input.GetAxis(_playerNumber + "_Square");
        inputValue["X"] = Input.GetAxis(_playerNumber + "_X");
        inputValue["Circle"] = Input.GetAxis(_playerNumber + "_Circle");
        inputValue["Triangle"] = Input.GetAxis(_playerNumber + "_Triangle");
        inputValue["L1"] = Input.GetAxis(_playerNumber + "_L1");
        inputValue["L2"] = Input.GetAxis(_playerNumber + "_L2");
        inputValue["R1"] = Input.GetAxis(_playerNumber + "_R1");
        inputValue["R2"] = Input.GetAxis(_playerNumber + "_R2");
    }

    // GETTERS
    public float GetInputValue(string key)
    {
        return inputValue[key];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScriptAlex : MonoBehaviour {

    private QuickEventInputManager _inputScript;
    public string _keyToTest;

	// Use this for initialization
	void Start () {
        _inputScript = gameObject.GetComponent<QuickEventInputManager>();
	}
	
	// Update is called once per frame
	void Update () {
        print(_inputScript.GetInputValue(_keyToTest));
	}
}

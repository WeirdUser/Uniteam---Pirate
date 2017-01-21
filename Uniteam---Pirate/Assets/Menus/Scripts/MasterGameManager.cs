using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameManager : MonoBehaviour {

    // Public
    public static MasterGameManager manager;

    // Private
    private bool[] _isPlayerReady;

    // This ensure that we only have 1 MasterGameManager at the same time, always
    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

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

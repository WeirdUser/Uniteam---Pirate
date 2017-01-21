using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour {

    bool isOccupied = false;

    public void acceptPlayer()
    {
        if(isOccupied == false)
        {
            isOccupied = true;
            function();
        }
        
    }

    public void removePlayer()
    {
        isOccupied = false;
    }
    


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            acceptPlayer();
        }

        if (Input.GetMouseButtonDown(1))
        { // if right button pressed...
            removePlayer();
        }
    }

    public abstract void function();
}

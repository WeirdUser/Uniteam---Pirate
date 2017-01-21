using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4ControllerTest : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        TestControllerInput();
        TestPlayerJoining();
    }

    private void TestPlayerJoining()
    {
        for(int i = 1; i <= 4; i++)
        {
            if (Input.GetAxis("P" + i + "_X") != 0)
            {
                print("Controller " + i + " is connected!");
            }
        }
    }

    private void TestControllerInput()
    {
        // PLAYER 1
        if (Input.GetAxis("P1_Horizontal") != 0)
        {
            print("P1_Horizontal");
        }
        if (Input.GetAxis("P1_Vertical") != 0)
        {
            print("P1_Vertical");
        }
        if (Input.GetAxis("P1_Square") != 0)
        {
            print("P1_Square");
        }
        if (Input.GetAxis("P1_X") != 0)
        {
            print("P1_X");
        }
        if (Input.GetAxis("P1_Circle") != 0)
        {
            print("P1_Circle");
        }
        if (Input.GetAxis("P1_Triangle") != 0)
        {
            print("P1_Triangle");
        }
        if (Input.GetAxis("P1_L1") != 0)
        {
            print("P1_L1");
        }
        if (Input.GetAxis("P1_R1") != 0)
        {
            print("P1_R1");
        }
        if (Input.GetAxis("P1_L2") != 0)
        {
            print("P1_L2");
        }
        if (Input.GetAxis("P1_R2") != 0)
        {
            print("P1_R2");
        }

        // PLAYER 2
        if (Input.GetAxis("P2_Horizontal") != 0)
        {
            print("P2_Horizontal");
        }
        if (Input.GetAxis("P2_Vertical") != 0)
        {
            print("P2_Vertical");
        }
        if (Input.GetAxis("P2_Square") != 0)
        {
            print("P2_Square");
        }
        if (Input.GetAxis("P2_X") != 0)
        {
            print("P2_X");
        }
        if (Input.GetAxis("P2_Circle") != 0)
        {
            print("P2_Circle");
        }
        if (Input.GetAxis("P2_Triangle") != 0)
        {
            print("P2_Triangle");
        }
        if (Input.GetAxis("P2_L1") != 0)
        {
            print("P2_L1");
        }
        if (Input.GetAxis("P2_R1") != 0)
        {
            print("P2_R1");
        }
        if (Input.GetAxis("P2_L2") != 0)
        {
            print("P2_L2");
        }
        if (Input.GetAxis("P2_R2") != 0)
        {
            print("P2_R2");
        }
    }
}

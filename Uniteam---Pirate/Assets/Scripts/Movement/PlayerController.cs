using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string playerName;
    private Rigidbody playerBody;
    private float speed = 3.0f;
    private bool stunned;
    private float stunTimer;

    private bool isOccupied = false;

    public bool braced { get; internal set; }

	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody>();
        braced = false;
        stunned = false;
        stunTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(!isOccupied){
            if (stunned)
            {
                this.GetComponent<CharacterController>().enabled = false;

                if (stunTimer < 5.0f)
                {
                    stunTimer += Time.deltaTime;
                } else
                {
                    stunned = false;
                }
            }
            else if(Input.GetButton(playerName + "_L1") && Input.GetButton(playerName + "_R1") &&
                Input.GetButton(playerName + "_L2") && Input.GetButton(playerName + "_R2")) // All four triggers are held
            {
                braced = true;
            }
            else
            {
                braced = false;

                float moveHorizontal = Input.GetAxis(playerName + "_Horizontal");

                Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);

                playerBody.AddForce(movement * speed);
            }
        }
        
        /*
        var x = Input.GetAxis("Horizontal") * Time.deltaTime;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        
        transform.Translate(x, 0, 0);
        //transform.Translate(0, 0, z);
        */
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    
    void OnTriggerEnter(Collider impact)
    {
        if (impact.gameObject.CompareTag("Wave") && !braced)
        {
            stunned = true;
        }
    }

    public bool getIsOccupied(){
        return isOccupied;
    }

    public void setIsOccupied(bool _isOccupied){
        isOccupied = _isOccupied;
        print("Ben ouui!");
    }

    public void stopPlayer(){
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}

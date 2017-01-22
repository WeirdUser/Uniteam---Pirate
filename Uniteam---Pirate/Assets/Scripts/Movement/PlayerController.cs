using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string playerName;
    private Rigidbody playerBody;
    [SerializeField ]private float speed = 0.01f;
    private bool stunned;
    private float stunTimer;

    private bool isOccupied = false;

    public bool braced { get; internal set; }
    private Animator anim;

	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        braced = false;
        stunned = false;
        stunTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        
       if(!isOccupied && gameObject.active){
            print(playerName);
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
                anim.SetBool("IsBracing", braced);
            }
            else
            {
                braced = false;
                anim.SetBool("IsBracing", braced);
                CharacterController controller = GetComponent<CharacterController>();
                if (controller.isGrounded) {

                    float moveHorizontal = Input.GetAxis(playerName + "_Horizontal");
                    Vector3 moveDirection = Vector3.zero;
                    print("voila: " + moveHorizontal);
                    moveDirection =  new Vector3(-moveHorizontal,0.0f,0.0f);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;   
                    int orientation = 1;   

                    if(moveHorizontal > 0){
                        transform.rotation = Quaternion.Euler(-90.0f, 90.0f, 0f);
                    }else if(moveHorizontal < 0){
                        transform.rotation = Quaternion.Euler(-90.0f, -90.0f, 0f);
                        orientation = -1;
                    }
                        
                    if(moveHorizontal != 0 && !anim.GetBool("IsMoving")){
                        anim.SetBool("IsMoving",true);
                    }else{
                        anim.SetBool("IsMoving",false);
                    }            
                    controller.Move(moveDirection * Time.deltaTime * orientation);
                }
                /*moveDirection.y -= gravity * Time.deltaTime;*/
                
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
        anim.SetBool("IsWorking", isOccupied);
        if(isOccupied){
            transform.rotation = Quaternion.Euler(-90.0f, -45.0f, 0f);
        }
    }


}

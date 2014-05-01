using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {


    public float movementSpeed = 5.0f;

    public float verticalVelocity = 0;
    public float jumpSpeed = 7.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController cc = GetComponent<CharacterController>();
        //Movement 
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;


        //Jumping
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if( cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }


        Vector3 speed = new Vector3(forwardSpeed, verticalVelocity, 0);

        

        cc.Move(speed * Time.deltaTime);

        
	}

    void LateUpdate()
    {
        
        //Camera.main.transform.position.y = 2.0;
    }
}

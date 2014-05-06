using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	Animator anim;
	CharacterController cc;
    //BoxCollider boxCol;

	public float jumpSpeed = 8.0f;
	public float gravity = 15.0F;
    
    public float slideHeight;
    public bool isSliding = false;
    public float slideTime = 0.01f;
    public float slideCounter = 0.01f;
    
	private Vector3 moveDirection = Vector3.zero;
    
	int jumpHash = Animator.StringToHash("Jump");
	int groundedHash = Animator.StringToHash("IsGrounded");
    int slideHash = Animator.StringToHash("Slide");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		cc = GetComponent<CharacterController>();
        //boxCol = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        
        

		float move = Input.GetAxis("Vertical");
		anim.SetFloat("Speed", move);

		
        //Jumping
		if(Input.GetKeyDown(KeyCode.Space) && cc.isGrounded && !isSliding)
		{
			Jump();
			anim.SetTrigger(jumpHash);
		}

        //Sliding
		if(cc.isGrounded)
		{
			anim.SetBool(groundedHash, true);

            if (Input.GetButton("Fire1")) 
            {
                Slide();
                //While løkke her
                slideCounter -= Time.deltaTime;
                Debug.Log(slideCounter);
                if (slideCounter <= 0)
                {
                    StandUp();
                    Debug.Log("We counted to 0!");
                    slideCounter = slideTime;
                }
            }

            if (Input.GetButtonDown("Fire2")) 
            {
                StandUp();
            }
		}

		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);
	}


    /*
     *  Methods
     */
     
	void Jump()
	{
		moveDirection.y = jumpSpeed;
		rigidbody.AddForce(Vector3.up * jumpSpeed);
	}

    void Slide()
    {    
        cc.height = 1f;
        cc.center = new Vector3(0, 0.5f, 0);
        isSliding = true;
        anim.SetTrigger(slideHash);
        
    }

    void StandUp()
    {
        cc.height = 2f;
        cc.center = new Vector3(0, 1f, 0);
        isSliding = false;
    }

}

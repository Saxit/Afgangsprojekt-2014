using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	Animator anim;
	CharacterController cc;
    //BoxCollider boxCol;

	public float jumpSpeed = 5.0f;
	public float gravity = 20.0F;
    public float slideHeight;
    public bool isSliding = false;
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


		if(cc.isGrounded)
		{
			anim.SetBool(groundedHash, true);

            if (Input.GetButton("Fire1")) 
            {
                Slide();
            }

            if (Input.GetButtonDown("Fire2")) 
            {
                StandUp();
            }
		}

		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);
	}

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

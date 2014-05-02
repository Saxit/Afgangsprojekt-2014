using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	Animator anim;
	CharacterController cc;

	public float jumpSpeed = 5.0f;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	int jumpHash = Animator.StringToHash("Jump");
	int groundedHash = Animator.StringToHash("IsGrounded");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		float move = Input.GetAxis("Vertical");
		anim.SetFloat("Speed", move);

		if(Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
		{

			Jump();
			anim.SetTrigger(jumpHash);
		}

		if(cc.isGrounded)
		{
			anim.SetBool(groundedHash, true);
		}
		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);
	}

	void Jump()
	{
		moveDirection.y = jumpSpeed;
		rigidbody.AddForce(Vector3.up * jumpSpeed);
	}

}

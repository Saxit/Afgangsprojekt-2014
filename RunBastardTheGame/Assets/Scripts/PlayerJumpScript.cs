using UnityEngine;
using System.Collections;

public class PlayerJumpScript : MonoBehaviour {

	public float JumpSpeed = 300.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
			Jump();
	}

	void Jump() {
		rigidbody.AddForce(Vector3.up *JumpSpeed);
	}
}

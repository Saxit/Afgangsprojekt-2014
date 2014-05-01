using UnityEngine;
using System.Collections;

public class PlayerRun : MonoBehaviour {


    public float movementSpeed = 5.0f;
    private Animator anim;
    public float animSpeed = 1.5f;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.speed = animSpeed;

        //Vector3 speed = new Vector3(v, 0, 0);

        //CharacterController cc = GetComponent<CharacterController>();
        //cc.SimpleMove(speed);
	}
}

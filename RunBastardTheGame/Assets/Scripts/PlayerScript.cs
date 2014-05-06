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

    public float swipeUp = 0.1f;
    public float swipeDown = -0.1f;


    public float slideCounter = 0.01f;
    private bool _isSliding = false;
    private string _demoText = "test";
	private Vector3 _moveDirection = Vector3.zero;
    
	private int _jumpHash = Animator.StringToHash("Jump");
	private int _groundedHash = Animator.StringToHash("IsGrounded");
    private int _slideHash = Animator.StringToHash("Slide");

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

        SwipeControls();
        KeyboardControls();

		_moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(_moveDirection * Time.deltaTime);
	}


    /*
     *  Methods
     */

    private void SwipeControls()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Find bevægelsen fra sidste frame til nu
            Vector2 deltaTouchPos = Input.GetTouch(0).deltaPosition;
            //Debug.Log("DeltaPos: " + Input.GetTouch(0).deltaPosition.y.ToString() + " SwipeY: " + swipeUp.ToString());


            //Hvis swipet er opadgående og spilleren har jordforbindelse
            if (deltaTouchPos.y > swipeUp && cc.isGrounded)
            {
                Jump();
                anim.SetTrigger(_jumpHash);
                _demoText = "Jump";
            }



            //Hvis swipet er nedadgående og spilleren har jordforbindelse
            if (deltaTouchPos.y < swipeDown && cc.isGrounded)
            {
                _demoText = "Duck";
                Slide();
                StartCoroutine(WaitForSlide());
            }
        }
    }

    private void KeyboardControls()
    {
        ////Jumping
        if (Input.GetButtonDown("Fire1") && cc.isGrounded)
        {
            Jump();
            anim.SetTrigger(_jumpHash);
            _demoText = "Jump";
        }

        //Sliding
        if (Input.GetButtonDown("Fire2") && cc.isGrounded)
        {
            _demoText = "Duck";
            Slide();
            StartCoroutine(WaitForSlide());
        }
    }

	void Jump()
	{
		_moveDirection.y = jumpSpeed;
		rigidbody.AddForce(Vector3.up * jumpSpeed);
	}

    void Slide()
    {    
        cc.height = 1f;
        cc.center = new Vector3(0, 0.5f, 0);
        isSliding = true;
        anim.SetTrigger(_slideHash);
        
    }

    void StandUp()
    {
        Debug.Log("standup");
        cc.height = 2f;
        cc.center = new Vector3(0, 1f, 0);
        isSliding = false;
    }

    IEnumerator WaitForSlide()
    {
        Debug.Log("waitforit");
        _moveDirection.y = 0;
        yield return new WaitForSeconds(1f);
        StandUp();

    }


    private void OnGUI()
    {
        Vector2 pos = Camera.main.ScreenToViewportPoint(this.transform.position);


        GUI.Label(new Rect(pos.x, pos.y, 200, 30), _demoText);
        //Debug.Log(pos.y);

    }
}

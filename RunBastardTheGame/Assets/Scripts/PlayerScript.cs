using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


    //BoxCollider boxCol;

    public float animSpeed = 1f;
	public float jumpForce = 8.0f;
	public float gravity = 15.0F;
    
    public float slideHeight;
    public float slideTime = 0.01f;

    public float swipeUp = 0.1f;
    public float swipeDown = -0.1f;
    public float slideCounter = 0.01f;

    private string _demoText = "test";
	private Vector3 _moveDirection = Vector3.zero;

    private Animator _anim;
    private CharacterController _cc;
    private AnimatorStateInfo _currentBaseState;
	private static int _jumpState = Animator.StringToHash("Base Layer.Jump");
    private static int _slideState = Animator.StringToHash("Base Layer.Slide");
    private static int _doubleJumpState = Animator.StringToHash("Base Layer.DoubleJump");
    private static int _runState = Animator.StringToHash("Base Layer.Run");

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
		_cc = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        _currentBaseState = _anim.GetCurrentAnimatorStateInfo(0);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

#if UNITY_ANDROID
        SwipeControls();
#endif

#if UNITY_EDITOR
        KeyboardControls();
#endif

		_moveDirection.y -= gravity * Time.deltaTime;
		_cc.Move(_moveDirection * Time.deltaTime);
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
            if (deltaTouchPos.y > swipeUp && _currentBaseState.nameHash == _runState)
            {
                Jump();
                _anim.SetTrigger("Jump");
                _demoText = "Jump";
            }
            //hvis swipet er opadgående, og spilleren i forvejen i luften
            else if(deltaTouchPos.y > swipeUp && _currentBaseState.nameHash == _jumpState)
            {
                Jump();
                _anim.SetTrigger("DoubleJump");
                _demoText = "Double Jump";
            }

            //Hvis swipet er nedadgående og spilleren har jordforbindelse
            else if (deltaTouchPos.y < swipeDown && _currentBaseState.nameHash == _runState)
            {
                _demoText = "Duck";
                _anim.SetTrigger("SlideParam");
                Slide();
                StartCoroutine(WaitForSlide());
            }
        }
    }

    private void KeyboardControls()
    {
        ////Jumping
        if (Input.GetButtonDown("Fire1") && _currentBaseState.nameHash == _runState)
        {
            Jump();
            _anim.SetTrigger("JumpParam");
            _demoText = "Jump";
        }

        else if (Input.GetButtonDown("Fire1") && _currentBaseState.nameHash == _jumpState)
        {
            Jump();
            _anim.SetTrigger("DoubleJumpParam");
            _demoText = "Double Jump";
        }

        //Sliding
        else if (Input.GetButtonDown("Fire2") && _currentBaseState.nameHash == _runState)
        {
            _demoText = "Duck";
            _anim.SetTrigger("SlideParam");
            Slide();
            StartCoroutine(WaitForSlide());
        }
    }

	void Jump()
	{
		_moveDirection.y = jumpForce;
		rigidbody.AddForce(Vector3.up * jumpForce);
	}

    void Slide()
    {    
        _cc.height = 1f;
        _cc.center = new Vector3(0, 0.5f, 0);
    }

    void StandUp()
    {
        Debug.Log("standup");
        _cc.height = 2f;
        _cc.center = new Vector3(0, 1f, 0);
       
    }

    IEnumerator WaitForSlide()
    {
        Debug.Log("waitforit");
        _moveDirection.y = 0;
        yield return new WaitForSeconds(1.4f);
        StandUp();

    }


    private void OnGUI()
    {
        Vector2 pos = Camera.main.ScreenToViewportPoint(this.transform.position);


        GUI.Label(new Rect(pos.x, pos.y, 200, 30), _demoText);
        //Debug.Log(pos.y);

    }
}

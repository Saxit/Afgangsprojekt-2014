using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float jumpForce = 300.0f;                    //Udgangspunktet for den kraft som bliver tildelt hop
	public float gravity = 15.0F;                       //Udgangspunktet for tyngdekraften
    public float swipeUp = 0.1f;                        //Udgangspunktet for hvor langt op af y-aksen der skal swipes for at det tæller
    public float swipeDown = -0.1f;                     //Udgangspunktet for hvor langt ned af y-aksen der skal swipes for at det tæller

    private string _demoText = "test";                  //debug tekst
    private Animator _anim;                             //reference til Animator-komponenten
    private CapsuleCollider _psysCol;                   //reference til den collider der håndterer fysik
    private CapsuleCollider _collisionCol;              //reference til den collider der benyttes som trigger
    private Rigidbody _body;
    private AnimatorStateInfo _currentBaseState;        //reference til den aktive controller-tilstand
	private static int _jumpState = Animator.StringToHash("Base Layer.Jump");                   //Konverter tilstandsnavnene til en hashværdi
    private static int _slideState = Animator.StringToHash("Base Layer.Slide");
    private static int _doubleJumpState = Animator.StringToHash("Base Layer.DoubleJump");
    private static int _runState = Animator.StringToHash("Base Layer.Run");
    private int _swipecount = 0;


	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();                                                   //Cache Animator komponenten
        _psysCol = GetComponent<CapsuleCollider>();                                         //Cache fysik collideren
        _body = GetComponent<Rigidbody>();                                        //Cache rigidbody
        _collisionCol = GameObject.Find("CollisionObj").GetComponent<CapsuleCollider>();     //Cache trigger collideren


	}
	
	// Update is called once per frame
	void Update () {
        _currentBaseState = _anim.GetCurrentAnimatorStateInfo(0);                           //Sæt den aktive tilstandsværdi 
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);    //Sikrer at GameObjektet aldrig afviger fra 0 på Z-aksen
        //_body.velocity = Vector3.right * 4.0f;


#if UNITY_ANDROID   //Hvis spillet afvikles på en Android maskine
        SwipeControls();
#endif

#if UNITY_EDITOR    //Hvis spillet afvikles på PC
        KeyboardControls();
#endif

	}



    /*
     *  Input-controller til Mobilversionen.
     *  Baseret på swipe input.
     */

    private void SwipeControls()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _swipecount = Input.touchCount;
            //Find bevægelsen fra sidste frame til nu
            Vector2 deltaTouchPos = Input.GetTouch(0).deltaPosition;
            //Debug.Log("DeltaPos: " + Input.GetTouch(0).deltaPosition.y.ToString() + " SwipeY: " + swipeUp.ToString());


            //Hvis swipet er opadgående og spilleren har jordforbindelse
            if (deltaTouchPos.y > swipeUp && _currentBaseState.nameHash == _runState)
            {
                Jump();
                _anim.SetTrigger("Jump");   //Opdaterer animatoren
                _demoText = "Jump";
            }
            //hvis swipet er opadgående, og spilleren i forvejen i luften
            else if(deltaTouchPos.y > swipeUp && _currentBaseState.nameHash == _jumpState)
            {
                Jump();
                _anim.SetTrigger("DoubleJump"); //Opdaterer animatoren
                _demoText = "Double Jump";
            }

            //Hvis swipet er nedadgående og spilleren har jordforbindelse
            else if (deltaTouchPos.y < swipeDown && _currentBaseState.nameHash == _runState)
            {
                _demoText = "Duck";
                _anim.SetTrigger("SlideParam"); //Opdaterer animatoren
                Slide();
                StartCoroutine(WaitForSlide());
            }
        }
    }


    /// <summary>
    /// Input-controller til PC-versionen
    /// Baseret på keyboard / mus-input
    /// </summary>
    private void KeyboardControls()
    {
        ////Jumping
        if (Input.GetButtonDown("Fire1") && _currentBaseState.nameHash == _runState)
        {
            
            _anim.SetTrigger("JumpParam");
            _demoText = "Jump";
            Jump();
            StartCoroutine(WaitForSlide());
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

    /// <summary>
    /// Giver kraft til gameobjektets Y-akse, hvilket løfter den.
    /// </summary>
	void Jump()
	{
		_body.AddForce(Vector3.up * jumpForce);
	}

    /// <summary>
    /// Ændrer størrelsen på GameObjektets fysik collider til en fjerdedel, 
    /// og placerer den i halv højde. 
    /// Slukker for collision collideren
    /// </summary>
    void Slide()
    {
        _collisionCol.enabled = false;
        
        _psysCol.height = 0.25f;
        _psysCol.center = new Vector3(0, 0.25f, 0);
    }

    /// <summary>
    /// Ændrer størrelsen på fysik collideren tilbage til 1,
    /// og placerer den tilbage i normal højde.
    /// Tænder for collision collideren
    /// </summary>
    void StandUp()
    {
        //Debug.Log("standup");
        _psysCol.height = 1f;
        _psysCol.center = new Vector3(0, 0.5f, 0);
        _collisionCol.enabled = true;
    }

    /// <summary>
    /// Venter 1.2 sekunder, og kalder StandUp()
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForSlide()
    {
        //Debug.Log("waitforit");
        yield return new WaitForSeconds(1.2f);
        StandUp();
    }


    /// <summary>
    /// Opdaterer demotekst
    /// </summary>
    private void OnGUI()
    {
        Vector2 pos = Camera.main.ScreenToViewportPoint(this.transform.position);


        GUI.Label(new Rect(pos.x, pos.y, 200, 30), _swipecount.ToString());
        //Debug.Log(pos.y);

    }
}

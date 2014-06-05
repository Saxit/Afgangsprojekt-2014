using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {

    public float jumpForce = 10f;
    public float gravity = 15f;

    private State _state;
    public npcSight _sight;
    public npcFeels _feels;
    private Transform _player;
    private Animator _anim;

	// Use this for initialization
	IEnumerator Start () {
        _state = State.Init;

        while (true)
        {
            switch(_state)
            {
                case State.Init:
                    Init();
                    break;
                case State.Walk:
                    Walk();
                    break;
                case State.Jump:
                    Jump();
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Die:
                    Die();
                    break;    
            }
            yield return 0;
        }
	}

    /// <summary>
   /// Komponenter findes og caches som det allerførste når scriptet starter.
   /// Fører udmiddelbart over i Walk tilstanden
   /// </summary>
    private void Init()
    {
        Debug.Log("Enemy init");
        _sight = this.transform.GetComponentInChildren<npcSight>();
        _feels = this.transform.GetComponentInChildren<npcFeels>();
        _anim = this.transform.GetComponentInChildren<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _state = State.Walk;
    }

    private void Walk()
    {
        //Debug.Log("Enemy Walk");

        if(_sight.playerInSight)
        {
            Debug.Log("set");
            _anim.SetBool("PlayerSeen", true);
            _state = State.Attack;
        }
        if(_feels.NpcJump)
        {
            _feels.NpcJump = false;
            _state = State.Jump;
        }

    }

    private void Jump()
    {
        Debug.Log("Enemy Jump");

        StartCoroutine(WaitForDoubleJump());
        
        _state = State.Walk;
    }

    private void Attack()
    {
        //Debug.Log("Enemy Attack");
        if(_sight.playerInSight)
        {
            _anim.applyRootMotion = false;
            Debug.Log("BANG!");
        }
        else
        {
            _state = State.Walk;
            _anim.applyRootMotion = true;
        }
    }
	
    private void Die()
    {
        Debug.Log("Enemy Dies");
        this.gameObject.SetActive(false);
    }


    IEnumerator WaitForDoubleJump()
    {
        Debug.Log("hop");
        rigidbody.AddForce(Vector3.up * jumpForce);
        yield return new WaitForSeconds(1.2f);
        rigidbody.AddForce(Vector3.up * (jumpForce * 1.5f));
        Debug.Log("hop");
    }

    public enum State
    {
        Init,
        Walk,
        Jump,
        Attack,
        Die
    }
}

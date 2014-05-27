using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {

    public float jumpForce = 10f;
    public float gravity = 15f;

    private Vector3 _moveDirection;
    private State _state;
    private npcSight _sight;
    private npcFeels _feels;
    private Transform _player;
    private Animator _anim;
    private CharacterController _cc;

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
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _cc = this.transform.GetComponent<CharacterController>();
        _moveDirection = Vector3.zero;
        _state = State.Walk;
    }

    private void Walk()
    {
        //Debug.Log("Enemy Walk");
        _moveDirection.y -= gravity * Time.deltaTime;
        _cc.Move(_moveDirection * Time.deltaTime);

        if(_sight.playerInSight)
        {
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
        //Debug.Log("Enemy Jump");
        _moveDirection.y = jumpForce;
        //this.rigidbody.AddForce(Vector3.up * jumpForce);
        _state = State.Walk;
    }

    private void Attack()
    {
        //Debug.Log("Enemy Attack");
        if(_sight.playerInSight)
        {
            _cc.Move(new Vector3(0, 0, 0));
            Debug.Log("BANG!");
        }
        else
        {
            //_state = State.Die;
        }
    }
	
    private void Die()
    {
        Debug.Log("Enemy Dies");
        this.gameObject.SetActive(false);
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

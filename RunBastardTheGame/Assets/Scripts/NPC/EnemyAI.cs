using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {

    public float jumpForce = 10f;
    public float gravity = 15f;
    public float timeBetweenShots = 0.5f;

    private State _state;
    public npcSight _sight;
    public npcFeels _feels;
    private Transform _player;
    private Animator _anim;
    private SpawnBullets _spawnBullets;
    private bool _isWaiting;

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
        _spawnBullets = this.transform.GetComponentInChildren<SpawnBullets>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _isWaiting = false;
        _state = State.Walk;
    }

    private void Walk()
    {
        //Debug.Log("Enemy Walk");
        if (!CheckForDeath())
        {
            if(_sight.playerInSight)
            {
                //Debug.Log("set");
                _anim.SetBool("PlayerSeen", true);
                _state = State.Attack;
            }
            else if(!_sight.playerInSight)
            {
                _anim.SetBool("PlayerSeen", false);
            }
            
            if(_feels.NpcJump)
            {
                _feels.NpcJump = false;
                _state = State.Jump;
            }
        }
        else
        {
            _state = State.Die;
        }

    }

    private void Jump()
    {
        Debug.Log("Enemy Jump");
        if (!CheckForDeath())
        { 
            StartCoroutine(WaitForDoubleJump());
            _state = State.Walk;
        }
        else
        {
            _state = State.Die;
        }
    }

    private void Attack()
    {
        if (!CheckForDeath())
        { 
        
            //Debug.Log("Enemy Attack");
            if(_sight.playerInSight)
            {
                _anim.applyRootMotion = false;
                if (!_isWaiting)
                {
                    _isWaiting = true;
                    _spawnBullets.Spawn();
                    StartCoroutine(WaitForNextShot());

                }
            }
            else
            {
                _state = State.Walk;
                _anim.applyRootMotion = true;
            }
        }
        else
        {
            _state = State.Die;
        }
        
    }
	
    private void Die()
    {
        Debug.Log("Enemy Dies");
        
        this.gameObject.SetActive(false);

    }


    private bool CheckForDeath()
    {
        bool dead = false;
        if(_feels.NpcHit == true) 
        {
            dead = true;
            _feels.NpcHit = false;
        }
        return dead;
    }

    IEnumerator WaitForDoubleJump()
    {
        Debug.Log("hop");
        rigidbody.AddForce(Vector3.up * jumpForce);
        yield return new WaitForSeconds(1.2f);
        rigidbody.AddForce(Vector3.up * (jumpForce * 1.5f));
        Debug.Log("hop");
    }

    IEnumerator WaitForNextShot()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        _isWaiting = false;

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

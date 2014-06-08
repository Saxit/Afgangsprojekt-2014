using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {

    public float jumpForce = 10f;               //Kraften som npc påvirkes med ved hop                 
    public float timeBetweenShots = 0.5f;       //Hvor ofte NPC kan skyde
    public float timeBetweenJumps = 1.2f;       //Tid imellem jump og doublejump

    private State _state;                       //håndterer NPC´s nuværende tilstand
    private npcSight _sight;                    //Reference til syns-script
    private npcFeels _feels;                    //Reference til feels-script
    private Transform _player;                  //Reference til Mojo
    private Animator _anim;                     //Reference til animator-komponenten
    private SpawnBullets _spawnBullets;         //Reference til SpawnBullets-scriptet
    private bool _isWaiting;                    //Sikrer at NPC ikke skyder non-stop

    //Start FSM
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

    /// <summary>
    /// Håndterer NPC´s walk-tilstand
    /// </summary>
    private void Walk()
    {
        //Se om NPC er blevet ramt af projektil
        if (!CheckForDeath())
        {
            //Se om spilleren kan ses.
            if(_sight.playerInSight)
            {
                _anim.SetBool("PlayerSeen", true); //Opdater controller-komponenten
                _state = State.Attack;             //Skift tilstand til attack
            }
            
            //Kontroller om npc´en har ramt et jumppoint
            if(_feels.NpcJump)
            {
                _feels.NpcJump = false; //reset NpcJump-variablen
                _state = State.Jump;    //skift til Jump-tilstand
            }
        }
        else
        {
            _state = State.Die; //skift til Die-tilstand
        }

    }

    /// <summary>
    /// Håndter NPC´s jump-tilstand
    /// </summary>
    private void Jump()
    {
        
        if (!CheckForDeath())
        { 
            StartCoroutine(WaitForDoubleJump());    //Start jump-coroutine
            _state = State.Walk;                    //Skift tilbage til Walk-tilstand
        }
        else
        {
            _state = State.Die;
        }
    }

    /// <summary>
    /// Håndter NPC´s Attack-tilstand
    /// </summary>
    private void Attack()
    {
        if (!CheckForDeath())
        { 
        
            //Hvis spilleren stadig kan ses
            if(_sight.playerInSight)
            {   
                _anim.applyRootMotion = false;          //Stop NPC´s bevægelse
                if (!_isWaiting)                        //Se om NPC venter på at kunne skyde
                {
                    _isWaiting = true;                  //Sørg for at NPC venter 
                    _spawnBullets.Spawn();              //Opretter et projektil-GO
                    StartCoroutine(WaitForNextShot());  //Start nedtælling til næste skud

                }
            }
            //Hvis spilleren ikke længere kan ses
            else
            {
                _state = State.Walk;                    
                _anim.applyRootMotion = true;           //Start NPC´s bevægelse igen
                _anim.SetBool("PlayerSeen", false);     //Opdatér controller-komponenten så Attack-animationen ikke længere vises.
            }
        }
        else
        {
            _state = State.Die;
        }
        
    }
	
    /// <summary>
    /// Oprydning efter NPC´en dør
    /// </summary>
    private void Die()
    {
        this.gameObject.SetActive(false); //Sæt NPC til inaktiv, hvorefter han igen indgår i spawn pool
    }


    /// <summary>
    /// Kontrollerer om NPC er blevet ramt af et projektil
    /// </summary>
    private bool CheckForDeath()
    {
        bool dead = false;
        if(_feels.NpcHit == true) 
        {
            dead = true;
            _feels.NpcHit = false;  //Reset NpcHit-property
        }
        return dead;
    }

    /// <summary>
    /// Udfører double jump
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForDoubleJump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce);             //tildel kraft til y-akse
        yield return new WaitForSeconds(timeBetweenJumps);      //ventetid før næste krafttilførsel
        rigidbody.AddForce(Vector3.up * (jumpForce * 1.5f));    //til kraft igen.
    }

    /// <summary>
    /// Sikrer en venteperiode imellem skud
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForNextShot()
    {
        yield return new WaitForSeconds(timeBetweenShots);  
        _isWaiting = false;

    }

    /// <summary>
    /// Definér NPC´s mulige tilstande.
    /// </summary>
    public enum State
    {
        Init,
        Walk,
        Jump,
        Attack,
        Die
    }
}

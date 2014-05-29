using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class npcSight : MonoBehaviour {

    public bool playerInSight;

    private SphereCollider _col;
    public  GameObject _player;



    void Awake()
    {
        _col = GetComponent<SphereCollider>();
        _player = GameObject.Find("CollisionObj");
    }

    /// <summary>
    /// Kaldes en gang pr. frame hvis en anden collider (other) rører den.
    /// Her, såfremt den anden collider er spilleren, og spilleren står foran NPC´en, sættes playerInsight variablen.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        //er trigger collideren på spilleren?
        if (other.gameObject.name == _player.name)
        {
            playerInSight = true;
        }
    }



    
      
}

using UnityEngine;
using System.Collections;

public class npcFeels : MonoBehaviour {

    public bool NpcJump { get; set; }
    public CapsuleCollider _col;

    void Awake()
    {
        _col = this.gameObject.GetComponent<CapsuleCollider>();
        
    }
    
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "JumpPoint")
        {
            NpcJump = true;
            //Debug.Log("WHEEE!!");
        }

    }

}

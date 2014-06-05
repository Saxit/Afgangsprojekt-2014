using UnityEngine;
using System.Collections;

public class npcFeels : MonoBehaviour {

    public bool NpcJump { get; set; }
    public bool NpcHit { get; set; }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "JumpPoint")
        {
            NpcJump = true;
        }

        if (other.gameObject.tag == "Projectile")
        {
            
            NpcHit = true;
        }
    }

}

using UnityEngine;
using System.Collections;

public class DeathOfObjects : MonoBehaviour {

    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //TODO: Game Over
            Debug.Break();

        }
        Debug.Log("her");

        //
        if (other.gameObject.transform.parent)
        {
            //find parent til det gameobject der har ramt væggen, og ødelæg det.
            //Så bliver alt fjernet, hvis det er et child der rammer.
            //Destroy(other.gameObject.transform.parent.gameObject);
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            //hvis der ikke er en parent
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        

    }
}

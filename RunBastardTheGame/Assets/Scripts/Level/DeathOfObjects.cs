﻿using UnityEngine;
using System.Collections;

public class DeathOfObjects : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //genstarter den nuværende scene
            Application.LoadLevel(Application.loadedLevel);

        }

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

    void OnTriggerEnter2D(Collider2D other)
    {
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

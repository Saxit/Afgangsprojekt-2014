using UnityEngine;
using System.Collections;

public class IsLevelEnd : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel("MainMenu");
        }
    }
}

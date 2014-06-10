using UnityEngine;
using System.Collections;

public class IsGameOver : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelEnd")
        {
            Application.LoadLevel("MainMenu");
            Debug.Log("Yay!");
        }
        else if (other.gameObject.tag == "Projectile")
        {
            Application.LoadLevel("LvlTrainWorld");
            Debug.Log("Boo!");
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Application.LoadLevel("MainMenu");
            Debug.Log("Boo!");
        }
    }
}

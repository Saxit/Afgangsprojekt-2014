using UnityEngine;
using System.Collections;

public class IsGameOver : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelEnd")
        {
            Application.LoadLevel("LvlTrainWorld");
            Debug.Log("Yay!");
        }
        else if (other.gameObject.tag == "Bullet")
        {
            Application.LoadLevel("LvlTrainWorld");
            Debug.Log("Boo!");
        }
    }
}

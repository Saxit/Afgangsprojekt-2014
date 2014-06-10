using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 200, 150), "<b>Zen Rabbit Studios</b> \n\n<b>Programmers</b> \nRonnie Hemmingsen \nToke Olsen \n\n<b>Graphics Design</b> \nNicholas Alberg");

        GUILayout.BeginArea(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height - Screen.height / 6, Screen.width / 2, Screen.height));
        GUILayout.BeginVertical("box");        

        bool backToMenu = GUILayout.Button("Back to main menu", GUILayout.Height(Screen.height / 10));

        GUILayout.EndVertical();
        GUILayout.EndArea();

        if (backToMenu)
        {
            Application.LoadLevel("MainMenu");
            Debug.Log("Back to main menu");
        }


    }
}

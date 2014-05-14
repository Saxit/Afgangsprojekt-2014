using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        
        GUILayout.BeginArea(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 6, Screen.width / 2, Screen.height));
        GUILayout.BeginVertical("box");
            //GUI.Box(new Rect(0, 0, 500, 500), "");
                    
            bool continueBut = GUILayout.Button("New Game / Continue", GUILayout.Height(Screen.height / 12));
            bool levelBut = GUILayout.Button("Level Select", GUILayout.Height(Screen.height / 12));
            bool tutorialBut = GUILayout.Button("Tutorials", GUILayout.Height(Screen.height / 12));
            bool optionsBut = GUILayout.Button("Options", GUILayout.Height(Screen.height / 12));
            bool creditsBut = GUILayout.Button("Credits", GUILayout.Height(Screen.height / 12));
            bool exitBut = GUILayout.Button("Exit", GUILayout.Height(Screen.height / 12));

        GUILayout.EndVertical();
        GUILayout.EndArea();
        

        if (continueBut)
        {
            Debug.Log("New game / Continue");
            
        }
            
        if (levelBut)
        {
            Application.LoadLevel("LevelSelect");
            Debug.Log("Level Select");
        }

        if (tutorialBut)
        {
            Application.LoadLevel("Tutorial");
            Debug.Log("Tutorial");
        }

        if (optionsBut)
        {
            Application.LoadLevel("Options");
            Debug.Log("Options");
        }

        if (creditsBut)
        {
            Application.LoadLevel("Credits");
            Debug.Log("Credits");
        } 

        if (exitBut)
        {
            Application.Quit();
            Debug.Log("Exit");
        }    


    }
}

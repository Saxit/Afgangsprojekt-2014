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
        
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 100, 500, 320));
        GUILayout.BeginVertical("box");
            GUI.Box(new Rect(0, 0, 500, 500), "");
                    
            bool continueBut = GUILayout.Button("Continue", GUILayout.Height(75));
            bool levelBut = GUILayout.Button("Level Select", GUILayout.Height(75));
            bool optionsBut = GUILayout.Button("Options", GUILayout.Height(75));
            bool exitBut = GUILayout.Button("Exit", GUILayout.Height(75));

        GUILayout.EndVertical();
        GUILayout.EndArea();
        

        if (continueBut)
        {
            Debug.Log("Continue");
            //Application.LoadLevel("MainMenu");
        }
            
        if (levelBut)
        {
            Application.LoadLevel("LevelSelect");
            Debug.Log("Level Select");
        }

        if (optionsBut)
        {
            Application.LoadLevel("Options");
            Debug.Log("Options");
        } 

        if (exitBut)
        {
            Application.Quit();
            Debug.Log("Exit");
        }    


    }
}

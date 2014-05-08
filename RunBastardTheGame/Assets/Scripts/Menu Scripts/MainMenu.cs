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
        GUI.BeginGroup(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 500));

            GUI.Box(new Rect(0, 0, 500, 500), "");
            GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 25, 400, 50) , "Continue");

            
                GUI.Button(new Rect(150, 10, 200, 50) , "Continue");
                GUI.Button(new Rect(150, 110, 200, 50), "Level Select");
                GUI.Button(new Rect(150, 210, 200, 50), "Options");
                GUI.Button(new Rect(150, 310, 200, 50), "Exit");
                //GUILayout.Button("Automatic layout");
                //GUILayout.Button("Automatic layout");
                //GUILayout.Button("Automatic layout");
                //GUILayout.Button("Automatic layout");
                //GUILayout.Button("Automatic layout");
            
        GUI.EndGroup();
    }
}

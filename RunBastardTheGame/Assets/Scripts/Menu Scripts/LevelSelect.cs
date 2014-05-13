using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI()
    {
        //Forward and back buttons
        GUI.Button(new Rect(0, 0, Screen.width / 10, Screen.height), "<");
        GUI.Button(new Rect(Screen.width - Screen.width / 10, 0, Screen.width / 10, Screen.height), ">");

        //Levels
        GUILayout.BeginHorizontal("");
        GUILayout.BeginArea(new Rect(Screen.width / 4 - Screen.width/ 8, Screen.height / 2 - 80, Screen.width, 240));                      
                GUILayout.BeginVertical("");
                    GUILayout.BeginHorizontal("");
                        GUILayout.Button("1-1", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                        GUILayout.Button("1-2", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                        GUILayout.Button("1-3", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                    GUILayout.EndHorizontal();

                    GUILayout.Button("Showdown!", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 5 + 5));
                GUILayout.EndVertical();
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 2 - 80, Screen.width, 240));
                GUILayout.BeginVertical("");
                    GUILayout.BeginHorizontal("");
                        GUILayout.Button("2-1", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                        GUILayout.Button("2-2", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                        GUILayout.Button("2-3", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                    GUILayout.EndHorizontal();

                    GUILayout.Button("Showdown!", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 5 + 5));
                GUILayout.EndVertical();
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(Screen.width * 0.75f - Screen.width / 8, Screen.height / 2 - 80, Screen.width, 240));
                GUILayout.BeginVertical("");
                    GUILayout.BeginHorizontal("");
                        GUILayout.Button("3-1", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                        GUILayout.Button("3-2", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                        GUILayout.Button("3-3", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 15));
                    GUILayout.EndHorizontal();

                    GUILayout.Button("Showdown!", GUILayout.Height(Screen.height / 10), GUILayout.Width(Screen.width / 5 + 5));
                GUILayout.EndVertical();
            GUILayout.EndArea();
        GUILayout.EndHorizontal();

        GUILayout.BeginArea(new Rect(Screen.width / 2 - (Screen.width / 4)/2, Screen.height - Screen.height / 10, Screen.width / 4, Screen.height));
            GUILayout.Button("Back to main menu", GUILayout.Height(Screen.height / 12));
        GUILayout.EndArea();
        
    }
}

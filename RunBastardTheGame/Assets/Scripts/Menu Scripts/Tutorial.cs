using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height - Screen.height / 6, Screen.width / 2, Screen.height));
        GUILayout.BeginVertical("box");
        //GUI.Box(new Rect(0, 0, 500, 500), "");

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

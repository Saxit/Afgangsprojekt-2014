using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    public GUIStyle tutImg01;
    public GUIStyle tutImg02;
    public GUIStyle tutImg03;

    public GUIStyle currentStyle;
    

    void Start()
    {
        currentStyle = tutImg01;
    }
    void OnGUI()
    {
        
        bool tutBut01 = GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", currentStyle);
        //bool tutBut02 = GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", currentStyle);
        //bool tutBut03 = GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", currentStyle);

        if (tutBut01 && currentStyle == tutImg01)
        {            
            currentStyle = tutImg02;
            Debug.Log("To page 2");
            tutBut01 = false;
        }
        if (tutBut01 && currentStyle == tutImg02)
        {
            currentStyle = tutImg03;
            Debug.Log("To page 3");
            tutBut01 = false;
        }
        if (tutBut01 && currentStyle == tutImg03)
        {
            Application.LoadLevel("MainMenu");
            Debug.Log("Finished");
        }



    }
}

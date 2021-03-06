﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public AudioClip buttonClick;
    public Object SoundManager;

    void Start()
    {
        SoundManager = GameObject.Find("SoundManager");
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
            Destroy(SoundManager);
            Debug.Log("New game / Continue");
            audio.PlayOneShot(buttonClick);
            Application.LoadLevel("LvlTrainWorld");
            
        }
            
        if (levelBut)
        {
            Application.LoadLevel("LevelSelect");
            audio.PlayOneShot(buttonClick);

            Debug.Log("Level Select");

        }

        if (tutorialBut)
        {
            Application.LoadLevel("Tutorial");
            audio.PlayOneShot(buttonClick);
            Debug.Log("Tutorial");
        }

        if (optionsBut)
        {
            Application.LoadLevel("Options");
            audio.PlayOneShot(buttonClick);
            Debug.Log("Options");
        }

        if (creditsBut)
        {
            Application.LoadLevel("Credits");
            audio.PlayOneShot(buttonClick);
            Debug.Log("Credits");
        } 

        if (exitBut)
        {
            Application.Quit();
            Debug.Log("Exit");
        }    


    }
}

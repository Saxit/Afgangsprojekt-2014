using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public float timeModifier = 0.1f;
    public float scoreValue = 10.0f;

    private float _accumulatedScore = 0.0f;
    private float _timer = 0.0f;


	
	// Update is called once per frame
	void Update () {

        CalculateScore();
        
	}


    private void CalculateScore()
    {
        _timer += timeModifier * Time.deltaTime;

        _accumulatedScore = scoreValue * _timer;

    }
    void OnGUI()
    {
        Vector2 pos = Camera.main.ScreenToViewportPoint(this.transform.position);


        GUI.Label(new Rect(pos.x + 350, pos.y, 200, 30), "Score: " + _accumulatedScore.ToString("F0"));

    }
}

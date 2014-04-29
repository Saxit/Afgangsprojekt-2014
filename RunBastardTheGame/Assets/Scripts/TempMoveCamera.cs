using UnityEngine;
using System.Collections;

public class TempMoveCamera : MonoBehaviour {

    public float speedModifier = 3.0f;

	// Use this for initialization
	void Start () {
    	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime * speedModifier);

	}
}

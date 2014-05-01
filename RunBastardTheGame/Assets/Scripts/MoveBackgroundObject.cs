using UnityEngine;
using System.Collections;

public class MoveBackgroundObject : MonoBehaviour {

    public float speed = 3.0f;
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);
	}
}

using UnityEngine;
using System.Collections;

public class LevelMover : MonoBehaviour {

    public float speed = 5.0f;
	
	// Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}

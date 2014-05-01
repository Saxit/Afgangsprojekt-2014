using UnityEngine;
using System.Collections;

public class TempMoveCamera : MonoBehaviour {

    public float speedModifier = 3.0f;
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime * speedModifier);

	}
}

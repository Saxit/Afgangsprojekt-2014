using UnityEngine;
using System.Collections;

public class DisableObj : MonoBehaviour {

    public float time = 2.0f;
    private float _countdown;

	// Use this for initialization
	void Start () {
        _countdown = time;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            this.gameObject.SetActive(false);
            time = _countdown;
        }

    }
}

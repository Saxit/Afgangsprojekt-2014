﻿using UnityEngine;
using System.Collections;

public class TempMoveCamera : MonoBehaviour {

    public Transform transformToFollow;
    public float distanceFromTransform = 5f;
    public float deltaX = 2f;
    public float deltaY = 2f;
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(transformToFollow.position.x + deltaX, transformToFollow.position.y + deltaY, transformToFollow.position.z - distanceFromTransform);
        

	}
}

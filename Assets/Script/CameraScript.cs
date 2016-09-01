﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public float movementSpeed = 5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float tiltX = Input.acceleration.x;
        transform.Translate(0,0,Time.deltaTime * movementSpeed);
        transform.Translate(tiltX * movementSpeed* Time.deltaTime, 0,0);

    }
}
﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public static float movementSpeed = 20f;
    private float tiltSpeed = 20f;

    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        float tiltX = Input.acceleration.x;
        transform.Translate(0,0,Time.deltaTime * movementSpeed);
        transform.Translate(tiltX * tiltSpeed * Time.deltaTime, 0,0);
        transform.Rotate(0, -Input.gyro.rotationRateUnbiased.z, 0);
    }
}

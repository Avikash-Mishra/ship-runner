using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {
  
    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -Input.gyro.rotationRateUnbiased.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("LETS HIT!!");
        
    }
}

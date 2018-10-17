using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddTorque(10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

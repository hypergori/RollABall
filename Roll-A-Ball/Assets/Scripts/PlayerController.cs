﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb ;
	public float speed;
	private bool gyroSupported;
	private Gyroscope gyo1;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		gyroSupported =  SystemInfo.supportsGyroscope;
		if (gyroSupported) {
			gyo1 = Input.gyro;
			gyo1.enabled = true;
			Debug.Log ("Gyro is not enabled");
		} else {
			Debug.Log("Gyro is not supported");
		}
	}

	
	// Update is called once per fixed time frame
	void FixedUpdate () {
		
		float moveHorizontal ;
		float moveVertical ;


		if (gyroSupported) {
			Vector3 v = gyo1.rotationRateUnbiased;
			moveHorizontal = v.y ;
			moveVertical = v.x*-1;
		} else {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}


		rb.AddForce (new Vector3 (moveHorizontal, 0, moveVertical)*speed);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive(false);
		}

	}
}

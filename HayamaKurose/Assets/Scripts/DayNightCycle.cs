using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
	//VERY simple day night cycle

	public float daySunAngularVelocity = 0.01f;
	public float nightSunAngularVelocity = 0.05f;		//Nights are shorter than the days

	private float sinInput = 0;
	private float ZA = 0;
	private float minZA = 45.0f;
	private float maxZA = 135.0f;
	public float sinAngVel = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Control day and night
		if (isDayTime()) {
			//Day time is slower than night time
			transform.Rotate(daySunAngularVelocity, 0, 0);
		}
		else {
			transform.Rotate(nightSunAngularVelocity, 0, 0);
		}

		//Angle the sun back and forth to simulate seasons
		var halfRange = (maxZA - minZA) / 2.0f;
		ZA = minZA + halfRange + Mathf.Sin(sinInput) * halfRange;
		transform.rotation.Set(transform.rotation.x, 0, sinInput, transform.rotation.w);
		sinInput += sinAngVel;
	}

	bool isDayTime() {
		if (transform.rotation.x > 0 && transform.rotation.x < 180)
			return true;
		else
			return false;
	}
}

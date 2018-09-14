using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
	//Simple day night cycle

	public float daySunAngularVelocity = 0.02f;
	public float nightSunAngularVelocity = 0.04f;		//Nights are shorter than the days

	public int days = 0;
	private bool previousDay;

	// public float sinAngVel = 0.5f;
	// private float sinInput = 0;
	// private float ZA = 0;
	// private float minZA = 45.0f;
	// private float maxZA = 135.0f;

	void FixedUpdate () {

		//Control day and night
		if (isDayTime()) {
			//Day time is slower than night time
			transform.Rotate(daySunAngularVelocity, 0, 0);
			// Debug.Log("Daytime!");
		}
		else {
			transform.Rotate(nightSunAngularVelocity, 0, 0);
			// Debug.Log("Nighttime!");
		}

		//If there's a transition between night and day, increment days
		if (previousDay == false && isDayTime()) 
			days++;
		previousDay = isDayTime();

		// //Angle the sun back and forth to simulate seasons
		// var halfRange = (maxZA - minZA) / 2.0f;
		// ZA = minZA + halfRange + Mathf.Sin(sinInput) * halfRange;
		// transform.rotation.Set(transform.rotation.x, 0, ZA, transform.rotation.w);
		// sinInput += sinAngVel;
	}

	bool isDayTime() {
		//THIS IS REALLY CRAP AND INEFFICIENT AND NEEDS MORE WORK
		float xa = transform.eulerAngles.x;
		// Debug.Log(xa);
		if (xa / 180 > 0.0f && xa / 180 < 1.0f ||		//DUMB
			xa / 180 > 2.0f && xa / 180 < 3.0f ||
			xa / 180 > -2.0f && xa / 180 < -1.0f)
			return true;
		else 
			return false;

	}


}

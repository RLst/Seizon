using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Seizon {

public class DayNightCycle : MonoBehaviour {
	//Place this on the directional sun ligth in the scene
	//And maybe attach a opposite directional moonlight

	public GameController GC;

	public float daySpeed = 0.03f;			//In degrees per frame; Good values =  0.2-0.3
	public float nightSpeed = 0.06f;		//Nights are shorter than the days; Good values = daySpeed *2
	private bool previousFrameWasDay;				//Required to check for new day transition
	private bool onFastForward = false;
	public float fastForwardMultiplier = 20f;

	void Start()
	{
		//Set sun to an early morning position
		transform.SetPositionAndRotation(new Vector3(0,0,0), new Quaternion(5f, 50f, 0, 0));
	}
	void FixedUpdate () {

		//Control day and night
		if (isDayTime()) {
			//Day time is slower than night time
			transform.Rotate(daySpeed, 0, 0);
			// Debug.Log("Daytime!");
		}
		else {
			transform.Rotate(nightSpeed, 0, 0);
			// Debug.Log("Nighttime!");
		}

		//If there's a transition between day and night ie. nightfall
		//Then let game controller know so it can start a new wave (day) of enemies
		if (previousFrameWasDay && !isDayTime())	//If previous frame was daytime and current frame is night time...
		{
			GC.StartNewDay();
		}

		//Handle fast forwards cessations
		if (onFastForward) {
			//If there's a transition between night and day ie. a new day has begun
			//then return to normal speed
			if (!previousFrameWasDay && isDayTime()) 
			{
				ReturnToNormalSpeed();
			}
			previousFrameWasDay = isDayTime();
		}
	}

	public bool isDayTime() {	//Returns true if day, false if night
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

	public void FastForward()
	{
		//Just fast forward by multiplying whatever speed by a certain constant amount that feels OK
		onFastForward = true;
		daySpeed *= fastForwardMultiplier;
		nightSpeed *= fastForwardMultiplier;
	}

	public void ReturnToNormalSpeed()
	{
		onFastForward = false;
		daySpeed /= fastForwardMultiplier;
		nightSpeed /= fastForwardMultiplier;
	}

}

}

	// public float sinAngVel = 0.5f;
	// private float sinInput = 0;
	// private float ZA = 0;
	// private float minZA = 45.0f;
	// private float maxZA = 135.0f;

		// //Angle the sun back and forth to simulate seasons
		// var halfRange = (maxZA - minZA) / 2.0f;
		// ZA = minZA + halfRange + Mathf.Sin(sinInput) * halfRange;
		// transform.rotation.Set(transform.rotation.x, 0, ZA, transform.rotation.w);
		// sinInput += sinAngVel;
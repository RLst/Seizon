using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Seizon {

public class DayNightCycle : MonoBehaviour {
	//Place this on the directional sun ligth in the scene
	//And maybe attach a opposite directional moonlight

	private GameController GC;

	public float daySpeed = 0.03f;			//In degrees per frame; Good values =  0.2-0.3
	public float nightSpeed = 0.06f;		//Nights are shorter than the days; Good values = daySpeed *2
	private bool isDayTime;
	private bool wasDayTime;				//Required to check for new day transition
	private bool onFastForward = false;
	
	public float fastForwardMultiplier = 20f;
	private float workingDaySpeed; private float workingNightSpeed;

	void Start()
	{
		GC = GameObject.FindObjectOfType<GameController>();

		//Saves the current speeds for reversion later
		workingDaySpeed = daySpeed;
		workingNightSpeed = nightSpeed;

		//Set sun to an early morning position
		transform.SetPositionAndRotation(new Vector3(0,0,0), new Quaternion(5f, 50f, 0, 0));

		CheckIfSunIsOut(out isDayTime);
		wasDayTime = isDayTime;
	}
	void FixedUpdate () 
	{
		wasDayTime = isDayTime;
		CheckIfSunIsOut(out isDayTime);

		//"Orbit" Sun and Moon
		if (isDayTime) {
            //Day time is slower than night time
            transform.Rotate(workingDaySpeed, 0, 0);
			// Debug.Log("Daytime!");
		}
		else {
            transform.Rotate(workingNightSpeed, 0, 0);
			// Debug.Log("Nighttime!");
		}

		if (SunriseHasOccured())
		{
			GC.dayCount++;
			GC.StartNewDay();
			if (onFastForward)
			{
				ReturnToNormalSpeed();
				onFastForward = false;
			}
		}
	}


	///Day cycle methods
	public void CheckIfSunIsOut(out bool isDayTime)
	{
		//THIS IS REALLY CRAP AND INEFFICIENT AND NEEDS MORE WORK
		float xa = transform.eulerAngles.x;
		// Debug.Log(xa);
		if (xa / 180 > 0.0f && xa / 180 < 1.0f ||		//DUMB
			xa / 180 > 2.0f && xa / 180 < 3.0f ||
			xa / 180 > -2.0f && xa / 180 < -1.0f)
			isDayTime = true;
		else 
			isDayTime = false;
	}
	private bool NightfallHasOccured()
	{
		if (wasDayTime && !isDayTime)
			return true;
		else 
			return false;
	}
	private bool SunriseHasOccured()
	{
		if (!wasDayTime && isDayTime)
			return true;
		else
			return false;
	}


	public void FastForward()
	{
		//Fast forwards to the morning?


		//Just fast forward by multiplying whatever speed by a certain constant amount that feels OK
		onFastForward = true;
		workingDaySpeed = daySpeed * fastForwardMultiplier;
		workingNightSpeed = nightSpeed * fastForwardMultiplier;
	}

	public void HandleFastForward()
	{
		//Stops the fast forward once a new day has begun
		if (onFastForward) {
			//If there's a transition between night and day ie. a new day has begun
			//then return to normal speed
			if (SunriseHasOccured())
			{
				ReturnToNormalSpeed();
				onFastForward = false;
			}
		}
	}

	public void ReturnToNormalSpeed()
	{
		workingDaySpeed = daySpeed;
		workingNightSpeed = nightSpeed;
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
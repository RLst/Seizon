using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

	public int gunDamage = 1;
	public float fireRateRPM = 600; 	//RPM
	private float timeBetweenShots;		//= 60 / fireRateRPM
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	public float weaponRange = 50f;
	public float hitForce = 100f;
	public Transform gunEnd;
	private AudioSource gunAudio;
	private LineRenderer debugLine;
	private float nextFire;
	private Camera fpsCam;


	// Use this for initialization
	void Start () {
		//Calculate fire rate per second
		timeBetweenShots = 60 / fireRateRPM;
		debugLine = GetComponent<LineRenderer>();
		gunAudio = GetComponent<AudioSource>();
		fpsCam = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + timeBetweenShots;
			StartCoroutine(ShotEffect());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
			RaycastHit hit;
			debugLine.SetPosition(0, gunEnd.position);

			//If the ray hits something
			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange)){
				debugLine.SetPosition(1, hit.point);
			}
			else {	//Otherwise set the end of the laser to weapon's range
				debugLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
			}

		}
	}

	private IEnumerator ShotEffect()
	{
		gunAudio.Play();
		debugLine.enabled = true;
		yield return shotDuration;
		debugLine.enabled = false;
	}

}

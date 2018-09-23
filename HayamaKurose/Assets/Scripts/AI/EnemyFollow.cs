using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Seizon {

public class EnemyFollow : MonoBehaviour {

	public NavMeshAgent nma;
	public GameObject player;	//AI behaviour target
	
	//public float maxSpeed;
	//public float acceleration;

	// Use this for initialization
	void Awake () {
		nma = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Fixed Update is called every 0.02 seconds (50fps)
	void FixedUpdate () {
	//	nma.acceleration = acceleration;
	//	nma.speed = maxSpeed;
		nma.destination = player.transform.position;
	}
}

}
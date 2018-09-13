using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour {

	public NavMeshAgent nma;
	public GameObject player;
	public float maxSpeed;
	public float acceleration;

	// Use this for initialization
	void Start () {
		nma = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Fixed Update is called every 0.02 seconds (50fps)
	void FixedUpdate () {
		nma.acceleration = acceleration;
		nma.speed = maxSpeed;
		nma.destination = player.transform.position;
	}
}

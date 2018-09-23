using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seizon {

public class SpawnManager : MonoBehaviour {

	public GameObject[] SpawnPositions;

	// Use this for initialization
	void Start () {
		SpawnPositions = GameObject.FindGameObjectsWithTag("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

}
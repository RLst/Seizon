// using System;
using UnityEngine;

namespace Seizon
{
    public class Spawner : MonoBehaviour {

	// public GameObject[] spawners;
	// public int RandomChance = 100;
	public GameController GC;
	public float SpawnDelayMin = 0;		//In seconds
	public float SpawnDelayMax = 5;
	private float nextSpawnTime = 100000000;	//Set to infinity

	//The object the spawner spawns
	public GameObject spawnSubject;		

	void Start()
	{
		GetNextSpawnTime();
	}


	void Update() 
	{
		///If there are enemies left to spawn
		if (GC.spawnsPerDay > 0) 
		// if (gameController.RemainingSpawnsToday > 0)
		{
			//Spawn one if the next spawn time reached
			if (Time.time >= nextSpawnTime) {
				Spawn();
			}
		}
		else ///No more enemies left so end the day (speed up the day)
		{
			// GameController.EndDay();
		}
	}

	void Spawn()
	{
		Instantiate(spawnSubject, transform.position, Quaternion.identity);		//Spawns an subject
		GC.spawnsPerDay--;		//Decrement count
		GetNextSpawnTime();		//Sets the next spawn time
	}

	float GetNextSpawnTime() {
		nextSpawnTime = Time.time + Random.Range(SpawnDelayMin, SpawnDelayMax);
		return nextSpawnTime;		//Flexibility
	}
}

}
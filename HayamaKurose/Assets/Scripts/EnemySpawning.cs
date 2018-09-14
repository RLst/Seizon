using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

	public SpawnManager SpawnManager;
	public GameObject Enemy;

// Wait timer -> Wait before first enemy spawning of the wave
	private float waitInterval = 5f;
	private float waitTimer = 0f;

// Spawn Timer -> Wait between enemies spawning
	public float spawnInterval = 2f;
	private float spawnTimer = 0f;

// Wave Managing Variables
	public int enemiesOnScreen = 0;
	public int enemies = 0;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnInterval;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		waitTimer += Time.deltaTime;
		spawnTimer += Time.deltaTime;

		if (waitTimer >= waitInterval)
		{
			if (spawnTimer >= spawnInterval)
			{
				GameObject NewEnemy = Instantiate(Enemy, SpawnManager.SpawnPositions[Random.Range (0, SpawnManager.SpawnPositions.Length)].transform.position, Quaternion.identity);
				enemiesOnScreen += 1;

				spawnTimer = 0;

				Debug.Log(enemiesOnScreen);	
			}	
		}
	}
}

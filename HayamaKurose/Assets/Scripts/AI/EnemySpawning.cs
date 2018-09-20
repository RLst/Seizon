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
	private int enemiesInRound = 20;
	public int addEnemiesPerWave = 5;	
	public int enemiesRemaining = 0;
	private bool isEnemyInScene = false;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnInterval;

		enemiesRemaining = enemiesInRound;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		waitTimer += Time.deltaTime;
		spawnTimer += Time.deltaTime;

		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
		{
			isEnemyInScene = false;
		}
		else
		{
			isEnemyInScene = true;
		}

		if (waitTimer >= waitInterval)
		{
			if (spawnTimer >= spawnInterval && enemiesRemaining >= 1)
			{
				GameObject NewEnemy = Instantiate(Enemy, SpawnManager.SpawnPositions[Random.Range (0, SpawnManager.SpawnPositions.Length)].transform.position, Quaternion.identity);
				enemiesRemaining -= 1;

				spawnTimer = 0;				
			}	
			else if (enemiesRemaining == 0 && isEnemyInScene == false)
			{
				enemiesInRound = enemiesInRound + addEnemiesPerWave;
				enemiesRemaining = enemiesInRound;

				waitTimer = 0;
			}
		}
	}
}

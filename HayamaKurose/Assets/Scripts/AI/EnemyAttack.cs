using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Seizon
{

public class EnemyAttack : MonoBehaviour {

	public int enemyDamage = 1;

	public BoxCollider attackCollider;
		
	// Use this for initialization
	void Start () {
		attackCollider = GetComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)     //Enemies touches the player
	{
		

		//Retrieve the player..
		var player = other.GetComponent<Player>();

		//And deal damage to the player
		player.health -= enemyDamage;
	}
}

}

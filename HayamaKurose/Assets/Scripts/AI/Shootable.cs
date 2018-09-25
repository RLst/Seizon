using UnityEngine;

namespace Seizon {
public class Shootable : MonoBehaviour {

	private GameController GC;
	public float health = 100f;
	public float deathDelayTime = 0;		//Seconds

	void Start()
	{
		//Find the one and only game controller
		GC = GameObject.FindObjectOfType<GameController>();
	}

	public void TakeDamage(float damageReceived)
	{
		health -= damageReceived;
		if (health <= 0f)
		{
			Die();
		}
	}

	void Die()
    {
		//play death animation
		Destroy(gameObject, deathDelayTime);
		//Update kill count
		GC.killCount++;
	}
}

}
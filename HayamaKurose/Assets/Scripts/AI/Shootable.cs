using UnityEngine;

namespace Seizon {
public class Shootable : MonoBehaviour {

	public float health = 100f;
	public float deathDelay = 0;

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
		Destroy(gameObject, deathDelay);
	}
}

}
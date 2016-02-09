using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxhealth = 100;
	int curhealth = 100;
	public bool invulnerable = false;
	public float hitStun = 0f;
	public float invulnerableTime = 1f;
	private float lastHit;

	// Use this for initialization
	void Spawn()
	{
		curhealth = maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnHit(int dmg)
	{
		curhealth -= dmg;
		if (curhealth <= 0)
		{
			OnDeath();
		}
	}

	void OnDeath()
	{
		//die and maybe respawn
	}
}

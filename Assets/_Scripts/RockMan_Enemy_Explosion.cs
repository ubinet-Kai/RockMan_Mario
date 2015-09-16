using UnityEngine;
using System.Collections;

public class RockMan_Enemy_Explosion : MonoBehaviour {

	public GameObject enemyExplosion;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") 
		{
			Instantiate(enemyExplosion, transform.position, transform.rotation); //enemy's explosion
		}
	}
}

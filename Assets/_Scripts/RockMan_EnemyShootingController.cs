using UnityEngine;
using System.Collections;

public class RockMan_EnemyShootingController : MonoBehaviour {

	public Transform enemySpawn;
	public GameObject RockMan_Enemy_Bullet;
	public float fireRate;

	private float nextFire;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(RockMan_Enemy_Bullet, enemySpawn.position, enemySpawn.rotation);
		}

	}
}

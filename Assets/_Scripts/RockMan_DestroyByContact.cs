using UnityEngine;
using System.Collections;

public class RockMan_DestroyByContact : MonoBehaviour {

	// Use this for initialization
	private RockMan_HealthController healthController;
	public GameObject explosion;


	void Start()
	{

		GameObject healthControllerObject = GameObject.FindWithTag("Player");

		if (healthControllerObject != null) 
		{
			healthController = healthControllerObject.GetComponent<RockMan_HealthController>();
		}
		if (healthController == null) 
		{
			Debug.Log ("Cannot find 'RockMan_HealthController' script");
		}
	}


	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "DamageObject" || other.tag == "Enemy" || other.tag == "EnemyBullet" || other.tag == "BossBullet")
		{

			//Instantiate(explosion, transform.position, transform.rotation); //should use Instantiate to play audio effect instead of Audio.play

			Destroy (other.gameObject);
			Destroy (gameObject);

		}
		else if (other.tag == "Boss") 
		{
			//audioSource.PlayOneShot(audioClip, 1.0f);
			//Instantiate(explosion, transform.position, transform.rotation);

			Destroy(gameObject);
			healthController.BossHealthController();
		
			if(healthController.bossHealthGauge <= 0)
			{
				Destroy(other.gameObject);
			}
		}

	}
}

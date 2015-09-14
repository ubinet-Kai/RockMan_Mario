using UnityEngine;
using System.Collections;

public class RockMan_DestroyByContact : MonoBehaviour {

	//private Animator m_animator;

	// Use this for initialization
	private RockMan_HealthController healthController;

	void Start()
	{
		GameObject healthControllerObject = GameObject.FindWithTag("Boss");
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
		if (other.tag == "DamageObject" || other.tag == "Enemy" || other.tag == "EnemyBullet")
		{
			//m_animator.Play("RockMan_Bullet_Effect");
			Destroy (other.gameObject);
			Destroy (gameObject);
			GetComponent<AudioSource> ().Play ();

		}
		else if (other.tag == "Boss") 
		{
			healthController.BossHealthController();
			Destroy(gameObject);

			if(healthController.bossHealthGauge <= 0)
			{
				Destroy(other.gameObject);

			}
		}

	}
}

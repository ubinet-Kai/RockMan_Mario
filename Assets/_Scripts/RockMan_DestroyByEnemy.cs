using UnityEngine;
using System.Collections;

public class RockMan_DestroyByEnemy : MonoBehaviour {

	private RockMan_HealthController healthController;
	private Animator m_animator;

	public GameObject playerExplosion;

	[SceneName]
    public string nextLevel;
	private float upSpeed = 100.0f;

	Rigidbody2D rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

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
		if (other.tag == "DamageObject" || other.tag == "Enemy" || other.tag == "Boss")
		{
			healthController.PlayerHealthController();

			if(healthController.playerHealthGauge <= 0)
			{
				Instantiate(playerExplosion, transform.position, transform.rotation); //to generate player's explosion effect

				rb.velocity = transform.up * upSpeed;
				StartCoroutine(INTERNAL_Restart());
			}

		}
		else if (other.tag == "EnemyBullet" || other.tag == "BossBullet") 
		{
			Destroy(other.gameObject);
			healthController.PlayerHealthController();

			if(healthController.playerHealthGauge <= 0)
			{
				Instantiate(playerExplosion, transform.position, transform.rotation);

				rb.velocity = transform.up * upSpeed;
				StartCoroutine(INTERNAL_Restart());
			}
		}

	}

	private IEnumerator INTERNAL_Restart()
	{

		yield return new WaitForSeconds(5);
		
		Application.LoadLevel(nextLevel);
	}
}

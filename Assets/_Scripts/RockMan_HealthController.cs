using UnityEngine;
using System.Collections;

public class RockMan_HealthController : MonoBehaviour {

	public int bossHealthGauge;
	public int playerHealthGauge;

	//public GameObject playerExplosion;

	[SceneName]
	public string nextLevel;
	
	public void BossHealthController()
	{
		bossHealthGauge--;

		if (bossHealthGauge <= 0)
		{
			StartCoroutine(INTERNAL_WinScene());
		}
	}

	public void PlayerHealthController()
	{
		playerHealthGauge--;

//		if (playerHealthGauge <= 0)
//		{
//			Instantiate(playerExplosion, transform.position, transform.rotation); //player's explosion
//		}
	}

	private IEnumerator INTERNAL_WinScene()
	{
		
		yield return new WaitForSeconds(2);
		
		Application.LoadLevel(nextLevel);
	}
}

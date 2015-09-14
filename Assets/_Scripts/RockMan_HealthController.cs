using UnityEngine;
using System.Collections;

public class RockMan_HealthController : MonoBehaviour {

	public int bossHealthGauge;
	public int playerHealthGauge;
	
	public void BossHealthController()
	{
		bossHealthGauge--;
	}

	public void playerHealthController()
	{
		playerHealthGauge--;
	}
}

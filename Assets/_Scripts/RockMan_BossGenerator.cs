using UnityEngine;
using System.Collections;

public class RockMan_BossGenerator : MonoBehaviour {

	public Transform spawn;
	public GameObject Enemy_Boss;
//	public bool isEnemy1Through;
//	public bool isEnemy2Through;
//	public bool isEnemy3Through;
	private bool isBossThrough;

//	private int size;

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")   
		{
			StartCoroutine(TimeWaiting());
		}

	}

	private IEnumerator TimeWaiting()
	{
		//GetComponent<BoxCollider2D>().isTrigger = false; // to avoid boss would be generated repeatedly

		yield return new WaitForSeconds(1);

//		if (!isEnemy1Through) {
//			for(int i = 0; i < size; i++)
//			{
//				GameObject[] enemy1 = new GameObject[i];
//				Vector2 spawnPosition = new Vector2
//					(
//						spawn.x, 
//						spawn.y
//					);
//				//create objects randomly based on "range"
//				Quaternion spawnRotation = Quaternion.identity;  // no rotation at all
//				Instantiate (Enemy_Boss[i], spawn[i].position, spawn[i].rotation);
//			}
//			isEnemy1Through = true;
//		}
//		else if (!isEnemy2Through) {
//			for(int i = 0; i < size; i++)
//			{
//				Instantiate (Enemy_Boss[i], spawn[i].position, spawn[i].rotation);
//			}
//			isEnemy2Through = true;
//		}
//		if (!isEnemy3Through) {
//			for(int i = 0; i < size; i++)
//			{
//				Instantiate (Enemy_Boss[i], spawn[i].position, spawn[i].rotation);
//			}
//			isEnemy3Through = true;
//		}
		if (!isBossThrough) 
		{
			//for(int i = 0; i < size; i++)
			//{
				Instantiate (Enemy_Boss, spawn.position, spawn.rotation);
			//}
			isBossThrough = true;
		}

	}
}

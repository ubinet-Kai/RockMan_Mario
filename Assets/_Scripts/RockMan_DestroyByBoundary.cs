using UnityEngine;
using System.Collections;

public class RockMan_DestroyByBoundary : MonoBehaviour {

void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Bullet" || other.tag == "Enemy") 
		{
			Destroy(other.gameObject);
		}
	}

}

using UnityEngine;
using System.Collections;

public class RockMan_DestroyByTime : MonoBehaviour {

	public float lifetime;
	
	void Start()
	{
		Destroy(gameObject, lifetime); // destroy itselves 
	}
}

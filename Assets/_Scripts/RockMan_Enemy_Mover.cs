using UnityEngine;
using System.Collections;

public class RockMan_Enemy_Mover : MonoBehaviour {

	public float enemySpeed;
	// Use this for initialization
	void Start () 
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.right * -1 * enemySpeed; 
		
	}
}

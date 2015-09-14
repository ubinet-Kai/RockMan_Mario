using UnityEngine;
using System.Collections;

public class RockMan_Bullet_Mover : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () 
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.right * speed; 

	}
	

}

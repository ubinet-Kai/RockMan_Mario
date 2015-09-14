using UnityEngine;
using System.Collections;

public class RockMan_Boss_Mover : MonoBehaviour {

	public float rightSpeed;
	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.right * Random.Range(0, -rightSpeed);  
	}
	
	void Update()
	{
		if (transform.position.x < 185.0f )
		{
			rb.velocity = transform.right * Random.Range(0, rightSpeed); 
		} 
		else if (transform.position.x > 197.0f) 
		{
			rb.velocity = transform.right * Random.Range(0, -rightSpeed); 

		}

	}
}

using UnityEngine;
using System.Collections;

public class RockMan_DestroyByContact : MonoBehaviour {

	//private Animator m_animator;

	// Use this for initialization

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "DamageObject" || other.tag == "Enemy") 
		{
			//m_animator.Play("RockMan_Bullet_Effect");
			Destroy (other.gameObject);
			Destroy (gameObject);
		}


	}
}

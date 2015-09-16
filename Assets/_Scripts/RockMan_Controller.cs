﻿using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class RockMan_Controller : MonoBehaviour
{
	public float maxSpeed = 10f;
	public float jumpPower = 1000f;
	public Vector2 backwardForce = new Vector2(-4.5f, 5.4f);

	public float fireRate;
	public Transform spawn;
	public GameObject RockMan_Bullet;
	
	public LayerMask whatIsGround;
	
	private Animator m_animator;
	private BoxCollider2D m_boxcollier2D;
	private Rigidbody2D m_rigidbody2D;
	private bool m_isGround;
	private const float m_centerY = 1.5f;

	private float nextFire; //default value is "0"

	private State m_state = State.Normal;
	
	void Reset()
	{
		Awake();
		
		// RockMan_Controller
		maxSpeed = 10f;
		jumpPower = 1000;
		backwardForce = new Vector2(-4.5f, 5.4f);
		whatIsGround = 1 << LayerMask.NameToLayer("Ground");
		
		// Transform
		transform.localScale = new Vector3(1, 1, 1);
		
		// Rigidbody2D
		m_rigidbody2D.gravityScale = 3.5f;
		//m_rigidbody2D.fixedAngle = true;
		
		// BoxCollider2D
		m_boxcollier2D.size = new Vector2(1, 2.5f);
		m_boxcollier2D.offset = new Vector2(0, -0.25f);
		
		// Animator
		m_animator.applyRootMotion = false;
	}
	
	void Awake()
	{
		m_animator = GetComponent<Animator>();
		m_boxcollier2D = GetComponent<BoxCollider2D>();
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		if (m_state != State.Damaged)
		{
			float x = Input.GetAxis("Horizontal");
			bool jump = Input.GetButtonDown("Jump");
			bool attack = Input.GetButton("Fire1");
			Move(x, jump, attack);
		}
	}
	
	void Move(float move, bool jump, bool attack)
	{
		if (Mathf.Abs(move) > 0)
		{
			Quaternion rot = transform.rotation;
			transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
		}
		
		m_rigidbody2D.velocity = new Vector2(move * maxSpeed, m_rigidbody2D.velocity.y);
		
		m_animator.SetFloat("Horizontal", move);
		m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
		m_animator.SetBool("isGround", m_isGround);

		if (jump && m_isGround)
		{
			m_animator.SetTrigger("Jump");
			SendMessage("Jump", SendMessageOptions.DontRequireReceiver);  //if Jump has sub-gameObject, 
			m_rigidbody2D.AddForce(Vector2.up * jumpPower);

		}

		/*when player running and standing on the ground*/
		if (move != 0 && m_isGround) 
		{
			if(attack)
			{
				if (Time.time > nextFire) 
				{
					nextFire = Time.time + fireRate;
					Instantiate (RockMan_Bullet, spawn.position, spawn.rotation);
					GetComponent<AudioSource>().Play();
					m_animator.Play ("Run_Attack");
				}
			}
			else
			{
				if(move > 0.1)
				{
					m_animator.Play ("Move Right");
				}
				else if(move < -0.1)
				{
					m_animator.Play("Move Left");
				}
			}
		} 
		/*when player was jumping*/
		else if (!m_isGround && !jump) 
		{ //press the jump key
			if(attack)
			{
				if (Time.time > nextFire) 
				{
					nextFire = Time.time + fireRate;

					if (m_rigidbody2D.velocity.y > 0.01 && m_rigidbody2D.velocity.y < 8)
					{
						Instantiate (RockMan_Bullet, spawn.position, spawn.rotation);
						GetComponent<AudioSource>().Play();
						m_animator.Play ("JumpUp_Attack");
					} 
					else if (m_rigidbody2D.velocity.y < 0.01)
					{
						Instantiate (RockMan_Bullet, spawn.position, spawn.rotation);
						GetComponent<AudioSource>().Play();
						m_animator.Play ("JumpDown_Attack");
					}
					else 	{
						Instantiate (RockMan_Bullet, spawn.position, spawn.rotation);
						GetComponent<AudioSource>().Play();
						m_animator.Play ("JumpTop_Attack");
					}
				}
			}
			else
			{
				if (m_rigidbody2D.velocity.y > 0.01 && m_rigidbody2D.velocity.y < 8)
				{
					m_animator.Play ("JumpUp");
				} 
				else if (m_rigidbody2D.velocity.y < 0.01)
				{
					m_animator.Play ("JumpDown");
				}
				else
				{
					m_animator.Play ("JumpTop");
				}
				
			}
		} 
		/*when player does not move and standing on the ground*/
		else if (move == 0 && m_isGround)   
		{
			if (attack) 
			{
				if(Time.time > nextFire)
				{
					nextFire = Time.time + fireRate;
					Instantiate (RockMan_Bullet, spawn.position, spawn.rotation);
					GetComponent<AudioSource>().Play();
					m_animator.Play ("Attack");
				}
			}
//			else
//			{
//				m_animator.Play ("Idle");
//			}
		} 
		/*devide Idle and attack for that animation can be played completely*/
		else if (!attack && move == 0 && m_isGround)
		{
				m_animator.Play ("Idle");
		}

	}
	
	void FixedUpdate()
	{
		Vector2 pos = transform.position;
		Vector2 groundCheck = new Vector2(pos.x, pos.y - (m_centerY * transform.localScale.y));
		Vector2 groundArea = new Vector2(m_boxcollier2D.size.x * 0.49f, 0.05f);
		
		m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
		m_animator.SetBool("isGround", m_isGround);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "DamageObject" || other.tag == "Enemy" || other.tag == "Boss" || other.tag == "BossBullet" || other.tag == "EnemyBullet" && m_state == State.Normal)
		{
			m_state = State.Damaged;
			StartCoroutine(INTERNAL_OnDamage());
		}
	}
	
	IEnumerator INTERNAL_OnDamage()
	{
		m_animator.Play(m_isGround ? "Damage" : "AirDamage");
		m_animator.Play("Idle");
		
		SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
		
		m_rigidbody2D.velocity = new Vector2(transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);
		
		yield return new WaitForSeconds(.1f);
		
		while (m_isGround == false)
		{
			//yield return new WaitForFixedUpdate();
			break;
		}

		m_animator.SetTrigger("Invincible Mode");
		m_state = State.Invincible;
	}
	
	void OnFinishedInvincibleMode()
	{
		m_state = State.Normal;
	}
	
	enum State
	{
		Normal,
		Damaged,
		Invincible,
	}
}

using UnityEngine;
using System.Collections;

public class RockMan_TimeWaiting : MonoBehaviour {

	// Use this for initialization
	private Animator m_animator;

	void Awake()
	{
		m_animator = GetComponent<Animator>();
	}
	void Start () 
	{
		StartCoroutine(TimeWaiting());
	}






private IEnumerator TimeWaiting()
{
	
	yield return new WaitForSeconds(2);
	
		m_animator.Play ("RockMan_WinPose");
}
}

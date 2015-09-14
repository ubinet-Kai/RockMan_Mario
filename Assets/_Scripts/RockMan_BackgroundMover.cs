using UnityEngine;
using System.Collections;

public class RockMan_BackgroundMover : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeX;
	
	private Vector2 startPosition; //if there is no startPosition, the background would turn to another position, instead of which 
	// we want to indicate.(in this script, we just want to indicate z axis)	
	void Start ()						
	{
		startPosition = transform.position;	
	}
	
	void Update ()
	{
		//   it is repeating from forward
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX); //notice the usage of mathf.repeat
		transform.position = startPosition + Vector2.right * -newPosition; //(direction, speed, size)



		//PlayerPrefs.GetInt ("Score");
	}	
}

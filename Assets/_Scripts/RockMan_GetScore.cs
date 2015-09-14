using UnityEngine;
using System.Collections;

public class RockMan_GetScore : MonoBehaviour {

	public GUIText score;
	// Use this for initialization
	void Awake()
	{
		score.text = PlayerPrefs.GetString("Point", score.text);
	}
}

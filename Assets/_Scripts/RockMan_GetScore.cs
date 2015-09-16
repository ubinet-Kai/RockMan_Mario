using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RockMan_GetScore : MonoBehaviour {

	public Text score;
	// Use this for initialization
	void Awake()
	{
		score.text = PlayerPrefs.GetString("Point", score.text);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text livesText;

	// Use this for initialization
	void Start ()
	{
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Lives", 20);

		scoreText.text = "" + PlayerPrefs.GetInt ("Score");
		livesText.text = "" + PlayerPrefs.GetInt ("Lives");
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreText.text = "" + PlayerPrefs.GetInt ("Score");
		livesText.text = "" + PlayerPrefs.GetInt ("Lives");
	}
}

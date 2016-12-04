using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	[Header ("UI")]
	public Text scoreText;
	public Text livesText;

	[Header ("Time")]
	public float startTimescale = 1.0f;
	public float increaseRate = 0.01f;

	void Start ()
	{
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Lives", 3);

		scoreText.text = "" + PlayerPrefs.GetInt ("Score");
		livesText.text = "" + PlayerPrefs.GetInt ("Lives");

		Time.timeScale = startTimescale;
	}

	void Update ()
	{
		scoreText.text = "" + PlayerPrefs.GetInt ("Score");
		livesText.text = "" + PlayerPrefs.GetInt ("Lives");

		Time.timeScale += increaseRate * Time.unscaledDeltaTime;
	}
}

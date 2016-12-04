using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	[Header ("UI")]
	public Text scoreText;
	public Text livesText;
	public Text difficultyText;

	[Header ("Time")]
	public float startTimescale = 1.0f;
	public float increaseRate = 0.01f;
	public float timeScaleNow;

	void Start ()
	{
		PlayerPrefs.SetInt ("Scores", 0);
		PlayerPrefs.SetInt ("Lives", 3);

		scoreText.text = "" + PlayerPrefs.GetInt ("Scores");
		livesText.text = "" + PlayerPrefs.GetInt ("Lives");

		Time.timeScale = startTimescale;
	}

	void Update ()
	{
		scoreText.text = "" + PlayerPrefs.GetInt ("Scores");
		livesText.text = "" + PlayerPrefs.GetInt ("Lives");

		Time.timeScale += increaseRate * Time.unscaledDeltaTime;
		timeScaleNow = Time.timeScale;
		//Time.fixedDeltaTime = Time.timeScale * 0.01667f;

		difficultyText.text = "" + Mathf.RoundToInt (Time.timeScale) + "";

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void HideMouse ()
	{
		Cursor.visible = false;
	}

	public void ShowMouse ()
	{
		Cursor.visible = true;
	}
}

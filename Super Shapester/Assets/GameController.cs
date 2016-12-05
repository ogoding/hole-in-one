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
		if (Time.timeScale <= Time.unscaledDeltaTime) 
		{
			Time.timeScale = Time.unscaledDeltaTime;
		}

		if (PlayerPrefs.GetInt ("Lives") > 0) 
		{
			Time.timeScale += increaseRate * Time.unscaledDeltaTime;
			difficultyText.text = "" + Mathf.RoundToInt (Time.timeScale) + "";
			scoreText.text = "" + PlayerPrefs.GetInt ("Scores");
			livesText.text = "" + PlayerPrefs.GetInt ("Lives");
		}

		if (PlayerPrefs.GetInt ("Lives") <= 0 && Time.timeScale > Time.unscaledDeltaTime) 
		{
			Time.timeScale -= Time.unscaledDeltaTime;
			Cursor.visible = true;
			ShowMouse ();
			GetComponent<MouseController> ().ShowMouse ();

			GameObject.Find ("BackgroundMusic").GetComponent<AudioPitchByTimescale> ().enabled = false;

			if (GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().pitch > 0) 
			{
				GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ().pitch -= 0.25f * Time.unscaledDeltaTime;
			}
		}

		timeScaleNow = Time.timeScale;

		if (Input.GetKeyDown (KeyCode.R) && PlayerPrefs.GetInt ("Lives") <= 0) 
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

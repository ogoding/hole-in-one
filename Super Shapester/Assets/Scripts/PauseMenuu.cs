using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuu : MonoBehaviour 
{
	public GameObject PauseUI;

	private bool paused = false;
	
	void Start()
	{
		PauseUI.SetActive (false);
	}
	
	void Update()
	{
		if (Input.GetButtonDown("Pause"))
		{
			paused = !paused;
		}
	
		if (paused)
		{
			PauseUI.SetActive(true);
			//Time.timeScale = 0;
		}

		if (!paused)
		{
			PauseUI.SetActive(false);
			//Time.timeScale = 1;
		}
	}
	
	public void Resume ()
	{
		paused = false;
	}
	
	public void Restart ()
	{
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	
	public void Main ()
	{
		//Application.LoadLevel(1);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	
	public void Quit ()
	{
		Application.Quit ();
	}
	
}
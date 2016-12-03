using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Application.targetFrameRate = -1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time.fixedDeltaTime = Time.timeScale * 0.016f;

		//Scene starts with menu up
		//Transition to bring up the game
		//Go back to menu when you die
	}

	public void ResetGame()
	{
		SceneManager.LoadScene ("main");
	}

	public void ChangeToInGame()
	{}

	public void ChangeToMenu()
	{}
}
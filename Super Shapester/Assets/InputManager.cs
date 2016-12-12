using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour 
{
    private enum Direction 
	{
        Up, Down, Left, Right
    }

	public float minX = -13;
	public float maxX = 13;
	public float minY = -7;
	public float maxY = 7;
    public float playerSpeed;

    public GameObject playerOne;
	public GameObject playerTwo;

	public Text highScoreText;
	public Button PlayButton;
	    
    void Update () 
	{		
		if (Input.GetKeyDown ("joystick button 7")) 
		{
			if (playerOne.activeInHierarchy == false) 
			{
				StartGame ();
			}

			if (GameObject.Find ("GameOverUI").activeInHierarchy == true) 
			{
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}

		HandleInput ("P1", playerOne);
		HandleInput ("P2", playerTwo);

		if (PlayerPrefs.GetInt ("HighScore", 0) < PlayerPrefs.GetInt ("Scores")) 
		{
			PlayerPrefs.SetInt ("HighScore", PlayerPrefs.GetInt ("Scores"));
		}

		highScoreText.text = "" + PlayerPrefs.GetInt ("HighScore") + "";
	}

	private void HandleInput(string playerID, GameObject player)
	{
		player.transform.position = new Vector3 
		(
			Mathf.Clamp (player.transform.position.x, -13, 13),
			Mathf.Clamp (player.transform.position.y, -7, 7),
			18
		);

		if (Input.GetAxis(playerID + "Horizontal") > 0)
		{
			player.transform.Translate(playerSpeed * (Input.GetAxis (playerID + "Horizontal")), 0, 0);
		}

		if (Input.GetAxis(playerID + "Horizontal") < 0)
		{
			player.transform.Translate(playerSpeed * (Input.GetAxis (playerID + "Horizontal")), 0, 0);
		}
			
		if (Input.GetAxis(playerID + "Vertical") > 0)
		{
			player.transform.Translate(0, playerSpeed * (Input.GetAxis (playerID + "Vertical")), 0);
		}

		if (Input.GetAxis (playerID + "Vertical") < 0) 
		{
			player.transform.Translate(0, playerSpeed * (Input.GetAxis (playerID + "Vertical")), 0);
		}

		if (Input.GetButtonDown(playerID + "NextShape"))
		{
			player.GetComponent<PlayerShape>().nextShape(Input.GetAxis(playerID + "NextShape") > 0);

			// Become Rectangle.
			if (player.GetComponent<PlayerShape> ().currentShape == 1) 
			{
				player.GetComponent<Animator> ().Play ("ToCube");
			}

			// Become Sphere.
			if (player.GetComponent<PlayerShape> ().currentShape == 0) 
			{
				player.GetComponent<Animator> ().Play ("ToSphere");
			}
		}
	}

	private bool PlayerCanMoveInDirection(Direction direction, GameObject player)
    {
        Vector3 playerLocation = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
				return playerLocation.y + (player.GetComponent<Rigidbody>().velocity.y * Time.fixedDeltaTime) < maxY;
            case Direction.Down:
				return playerLocation.y - (player.GetComponent<Rigidbody>().velocity.y * Time.fixedDeltaTime) > minY;
            case Direction.Left:
				return playerLocation.x - (player.GetComponent<Rigidbody>().velocity.x * Time.fixedDeltaTime) > minX;
            case Direction.Right:
				return playerLocation.x + (player.GetComponent<Rigidbody>().velocity.x * Time.fixedDeltaTime) < maxX;
        }
        return false;
    }

	public void StartGame ()
	{
		PlayButton.onClick.Invoke ();
	}
}

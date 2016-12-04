using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    private enum Direction {
        Up, Down, Left, Right
    }
	public float minX = -13;
	public float maxX = 13;
	public float minY = -7;
	public float maxY = 7;
    public float playerSpeed;

    public GameObject playerOne;
	public GameObject playerTwo;

    private void Start()
    {
    }
    
    void Update () 
	{
		HandleInput ("P1", playerOne);

		if (playerTwo != null)
			HandleInput ("P2", playerTwo);
	}

	private void HandleInput(string playerID, GameObject player)
	{
		if (Input.GetButton(playerID + "Horizontal"))
		{
			if (Input.GetAxis(playerID + "Horizontal") > 0 && PlayerCanMoveInDirection(Direction.Right, player))
			{
				//player.transform.Translate(playerSpeed * (1 / Time.timeScale), 0, 0);
				player.GetComponent<Rigidbody> ().AddRelativeForce (playerSpeed * (1 / Time.timeScale), 0, 0, ForceMode.VelocityChange);

			}
			else if (PlayerCanMoveInDirection(Direction.Left, player))
			{
				//player.transform.Translate((-1 * playerSpeed) * (1 / Time.timeScale), 0, 0);
				player.GetComponent<Rigidbody> ().AddRelativeForce ((-1 * playerSpeed) * (1 / Time.timeScale), 0, 0, ForceMode.VelocityChange);
			}
		}

		if (Input.GetButton(playerID + "Vertical"))
		{
			if (Input.GetAxis(playerID + "Vertical") > 0 && PlayerCanMoveInDirection(Direction.Up, player))
			{
				//player.transform.Translate(0, playerSpeed * (1 / Time.timeScale), 0);
				player.GetComponent<Rigidbody> ().AddRelativeForce (0, playerSpeed * (1 / Time.timeScale), 0, ForceMode.VelocityChange);
			}
			else if (PlayerCanMoveInDirection(Direction.Down, player))
			{
				//player.transform.Translate(0, (-1 * playerSpeed) * (1 / Time.timeScale), 0);
				player.GetComponent<Rigidbody> ().AddRelativeForce (0, (-1 * playerSpeed) * (1 / Time.timeScale), 0, ForceMode.VelocityChange);
			}
		}

		if (Input.GetButtonDown(playerID + "NextShape"))
		{
			player.GetComponent<PlayerShape>().nextShape(Input.GetAxis(playerID + "NextShape") > 0);
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
}

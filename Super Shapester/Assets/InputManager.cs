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
        //player = GameObject.FindGameObjectWithTag("Player");
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
				player.transform.Translate(playerSpeed, 0, 0);
			}
			else if (PlayerCanMoveInDirection(Direction.Left, player))
			{
				player.transform.Translate(-1 * playerSpeed, 0, 0);
			}
		}

		if (Input.GetButton(playerID + "Vertical"))
		{
			if (Input.GetAxis(playerID + "Vertical") > 0 && PlayerCanMoveInDirection(Direction.Up, player))
			{
				player.transform.Translate(0, playerSpeed, 0);
			}
			else if (PlayerCanMoveInDirection(Direction.Down, player))
			{
				player.transform.Translate(0, -1 * playerSpeed, 0);
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
                return playerLocation.y + playerSpeed < maxY;
            case Direction.Down:
                return playerLocation.y - playerSpeed > minY;
            case Direction.Left:
                return playerLocation.x - playerSpeed > minX;
            case Direction.Right:
                return playerLocation.x + playerSpeed < maxX;
        }
        return false;
    }
}

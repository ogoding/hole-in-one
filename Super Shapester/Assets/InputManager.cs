using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    private enum Direction {
        Up, Down, Left, Right
    }
    public float minX, maxX, minY, maxY;
    public float playerSpeed;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update () {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0 && PlayerCanMoveInDirection(Direction.Right))
            {
                player.transform.Translate(playerSpeed, 0, 0);
            }
            else if (PlayerCanMoveInDirection(Direction.Left))
            {
                player.transform.Translate(-1 * playerSpeed, 0, 0);
            }
        }

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0 && PlayerCanMoveInDirection(Direction.Up))
            {
                player.transform.Translate(0, playerSpeed, 0);
            }
            else if (PlayerCanMoveInDirection(Direction.Down))
            {
                player.transform.Translate(0, -1 * playerSpeed, 0);
            }
        }

        if (Input.GetButtonDown("NextShape"))
        {
            player.GetComponent<PlayerShape>().nextShape(Input.GetAxis("NextShape") > 0);
        }
	}

    private bool PlayerCanMoveInDirection(Direction direction)
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

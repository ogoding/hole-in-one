using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public float playerSpeed;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update () {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                player.transform.Translate(playerSpeed, 0, 0);
            }
            else
            {
                player.transform.Translate(-1 * playerSpeed, 0, 0);
            }
        }

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                player.transform.Translate(0, playerSpeed, 0);
            }
            else
            {
                player.transform.Translate(0, -1 * playerSpeed, 0);
            }
        }

        if (Input.GetButtonDown("NextShape"))
        {
            player.GetComponent<PlayerShape>().nextShape(Input.GetAxis("NextShape") > 0);
        }
	}
}

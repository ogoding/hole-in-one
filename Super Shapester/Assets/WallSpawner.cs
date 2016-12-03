using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawner : MonoBehaviour {
	public GameObject wallAnchor;
	public GameObject player;
	public List<GameObject> walls;
	public Transform WALL_SPAWN_POS;
	public float SPAWN_INTERVAL;	
	private float lastSpawnTime;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		walls = new List<GameObject> ();
		lastSpawnTime = 0;
		//WALL_SPAWN_POS.position = new Vector3 (0, 1, 0);
		walls.Add((GameObject)Instantiate (wallAnchor, WALL_SPAWN_POS.position, Quaternion.identity));
	}

	// Update is called once per frame
	void Update () 
	{
		if (ReadyToSpawn()) 
		{
			lastSpawnTime = Time.realtimeSinceStartup;
			walls.Add((GameObject)Instantiate (wallAnchor, WALL_SPAWN_POS.position, Quaternion.identity));
		}

		// Destroy first wall if it has reached the camera
		if (walls.Count > 0)
		{
			GameObject firstWall = walls[0].transform.GetChild (0).gameObject;

			if (PlayerInShape(player, firstWall))
			{
				Debug.Log("Player is colliding with cutout!");
			}
				
			if (ReachedCamera (firstWall))
			{
				GameObject wallToDestroy = walls[0];
				Debug.Log ("Reached Camera");
				walls.RemoveAt(0);
				Destroy (wallToDestroy);
			}
		}
	}			

	private bool PlayerInShape(GameObject player, GameObject wall)
	{
		Debug.Log ("Wall is null: " + walls [0] == null);
		Debug.Log ("Wall Component is null: " + walls [0].GetComponent<WallComponent> () == null);
		Debug.Log ("Player is null: " + player == null);

		return wall.GetComponent<WallComponent> ().TestOverlapping (player.GetComponent<Shape> ());
	}

	private bool ReachedCamera(GameObject wall)
	{
		return wall.transform.localPosition.z >= 120;
	}

	private bool ReadyToSpawn()
	{
		return Time.realtimeSinceStartup - lastSpawnTime >= SPAWN_INTERVAL;
	}		
}
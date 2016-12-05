using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawner : MonoBehaviour {
	public GameObject wall;
	public GameObject player;
	public List<GameObject> walls;
	public Transform WALL_SPAWN_POS;
	public float SPAWN_INTERVAL;
	public float WALL_SPEED;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () 
	{
		WALL_SPEED = 0.5f;
		player = GameObject.FindGameObjectWithTag("Player");
		walls = new List<GameObject> ();
		lastSpawnTime = 0;
		//WALL_SPAWN_POS.position = new Vector3 (0, 1, 0);
	}

	private void AddWall()
	{
		walls.Add((GameObject)GameObject.Instantiate(wall, WALL_SPAWN_POS.position, Quaternion.identity));
		WALL_SPEED += 0.1f;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (ReadyToSpawn()) 
		{
			lastSpawnTime = Time.realtimeSinceStartup;
			AddWall ();
		}

		// Destroy first wall if it has reached the camera
		if (walls.Count > 0)
		{
			GameObject firstWall = walls [0];
				
			if (ReachedCamera (firstWall))
			{
				Debug.Log ("A wall is destroyed");
				walls.RemoveAt(0);
				Destroy (firstWall);
			}
		}
	}

	private bool PlayerInShape(GameObject player, GameObject wall)
	{
		return wall.GetComponent<WallComponent> ().TestOverlapping (player.GetComponent<Shape> ());
	}

	private bool ReachedCamera(GameObject wall)
	{
		return false;
		//return wall.transform.position.z <= 2.2f;
	}

	private bool ReadyToSpawn()
	{
		return Time.realtimeSinceStartup - lastSpawnTime >= SPAWN_INTERVAL;
	}		
}
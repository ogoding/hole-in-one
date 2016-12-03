using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawner : MonoBehaviour {
	public GameObject wallAnchor;
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
		AddWall();
	}

	private void AddWall()
	{
		GameObject newWall = (GameObject)Instantiate(wallAnchor, WALL_SPAWN_POS.position, Quaternion.identity);
		newWall.transform.GetChild(0).gameObject.GetComponent<Move>().velocity = new Vector3(0, 0, -WALL_SPEED);
		walls.Add (newWall);

		WALL_SPEED += 0.1f;
	}

	// Update is called once per frame
	void Update () 
	{
		if (ReadyToSpawn()) 
		{
			lastSpawnTime = Time.realtimeSinceStartup;
			AddWall ();
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
				walls.RemoveAt(0);
				Destroy (wallToDestroy);
			}
		}
	}

	private bool PlayerInShape(GameObject player, GameObject wall)
	{
		return wall.GetComponent<WallComponent> ().TestOverlapping (player.GetComponent<Shape> ());
	}

	private bool ReachedCamera(GameObject wall)
	{
		return wall.transform.localPosition.z >= 133;
	}

	private bool ReadyToSpawn()
	{
		return Time.realtimeSinceStartup - lastSpawnTime >= SPAWN_INTERVAL;
	}		
}
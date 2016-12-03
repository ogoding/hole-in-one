using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawner : MonoBehaviour {
	public GameObject wallAnchor;
	public List<GameObject> walls;
	public Transform WALL_SPAWN_POS;
	public float SPAWN_INTERVAL;	
	private float lastSpawnTime;

	// Use this for initialization
	void Start () 
	{
		walls = new List<GameObject> ();
		lastSpawnTime = 0;
		//WALL_SPAWN_POS.position = new Vector3 (0, 1, 0);
		walls.Add((GameObject)Instantiate (wallAnchor, WALL_SPAWN_POS.position, Quaternion.identity));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ReadyToSpawn ()) 
		{
			lastSpawnTime = Time.realtimeSinceStartup;
			walls.Add((GameObject)Instantiate (wallAnchor, WALL_SPAWN_POS.position, Quaternion.identity));
		}

		// Destroy wall if it has reached the camera
		foreach (GameObject wallAnchor in walls) 
		{
			GameObject wall = wallAnchor.transform.GetChild (0).gameObject;

			if (ReachedCamera (wall))
			{
				Debug.Log ("Reached Camera");
				walls.Remove(wallAnchor);
				Destroy (wallAnchor);
			}
		}			

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No player found!");
            return;
        }


        if (walls.Count > 0)
        {
            if (walls[0].GetComponent<WallComponent>().TestOverlapping(player.GetComponent<Shape>()))
            {
                Debug.Log("Player is colliding with cutout!");
            }
        }
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
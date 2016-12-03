using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawner : MonoBehaviour {
	public GameObject wallAnchor;
	public List<GameObject> walls;
	public Transform WALL_SPAWN_POS;
	public int SPAWN_INTERVAL;	
	private float lastSpawnTime;
	private static float yRotLastFrame;

	// Use this for initialization
	void Start () 
	{
		walls = new List<GameObject> ();
		StartCoroutine (Spawn ()); 
		lastSpawnTime = 0;
		//WALL_SPAWN_POS.position = new Vector3 (0, 1, 0);
		Instantiate (wallAnchor, WALL_SPAWN_POS.position, Quaternion.identity);
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
		foreach (GameObject wall in walls) 
		{
			if (ReachedCamera (wall))
			{
				walls.Remove(wall);
				Destroy (wall);
			}
		}			

		DetachWall ();
		yRotLastFrame = wallAnchor.transform.rotation.eulerAngles.y;
	}

	private IEnumerator Spawn()
	{
		while (true) 
		{
			yield return new WaitForSeconds (SPAWN_INTERVAL);
		}
	}

	private bool ReachedCamera(GameObject wall)
	{
		return wall.gameObject.transform.position.z <= 0;
	}

	private bool ReadyToSpawn()
	{
		return Time.realtimeSinceStartup - lastSpawnTime >= SPAWN_INTERVAL;
	}

	private void DetachWall()
	{
		float yRotThisFrame = wallAnchor.transform.rotation.eulerAngles.y;

		// If the anchor has hit 180 rotation and the wall is ready to be detached
		if (yRotLastFrame == 0 && yRotThisFrame == 180) 
		{
			Debug.Log ("Detached!");
			//wallAnchor.transform.rotation = Quaternion.Euler (90, 0, 0);
		}

			//walls [0].transform.parent = null;
			//wallAnchor.transform.rotation = Quaternion.Euler (90, 0, 0);
	}
		
}
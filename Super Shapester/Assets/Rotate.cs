using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//gameObject.transform.position = new Vector3 (0, 13, 50);
		//gameObject.transform.eulerAngles = new Vector3 (Mathf.Clamp(gameObject.transform.rotation.x, 90, 180), 
		//	Mathf.Clamp (gameObject.transform.rotation.y, 0, 0), 
		//	Mathf.Clamp (gameObject.transform.rotation.z, 0, 0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		//World ANchor is replaced by vector 3
		//RotateAroundPoint
		//gameObject.transform.Rotate (1, 0, 0);


		//gameObject.transform.rotation = Quaternion.Euler (gameObject.transform.rotation.eulerAngles.x, 0, 0);
	}
}
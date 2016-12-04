using UnityEngine;
using UnityStandardAssets.Utility;
using System.Collections;

public class Move : MonoBehaviour
{
	public Vector3 velocity;
	public Rigidbody rb; 

	// Use this for initialization
	void Start () 
	{
		//velocity = new Vector3 (0, 0, -1);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		//gameObject.transform.position += velocity;
	}
}
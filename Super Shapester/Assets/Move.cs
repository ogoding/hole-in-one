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
		gameObject.GetComponent<Move>().enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		gameObject.transform.position += velocity;
	}
}
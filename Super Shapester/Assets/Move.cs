using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public Vector3 velocity;
	public Rigidbody rb; 

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {		
	}
}

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	public Vector3 velocity;
	public Rigidbody rb; 

	// Use this for initialization
	void Start () 
	{		
		//gameObject.transform.parent = GameObject.Find ("WallAnchor").transform;
		//gameObject.transform.localPosition = new Vector3 (gameObject.transform.localScale.x / 2, 0, 0);
		//gameObject.transform.rotation = Quaternion.Euler (0, 0, 0); 
		//rb = GetComponent<Rigidbody> ();
		//rb.velocity = velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
//		Vector3 pt = new Vector3(0, 13, 50);
//		Vector3 axis = new Vector3 (360, 0, 0);
//		float angle = 90;
//		
		//gameObject.transform.RotateAround(gameObject.transform.position, Vector3.right, 1);
		//gameObject.transform.Rotate(0.005f, 0, 0);

	}
}

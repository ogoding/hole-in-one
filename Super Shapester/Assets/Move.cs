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
		if (gameObject.transform.position.z <= 0)
        {
            gameObject.transform.position = new Vector3(0, 1, 150);
        }	
	}
}

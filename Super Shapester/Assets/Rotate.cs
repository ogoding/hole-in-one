using UnityEngine;
using UnityStandardAssets.Utility;
using System.Collections;
using System.Collections.Generic;

public class Rotate : MonoBehaviour {
	
	// Update is called once per frame
	/*void Update () 
	{
		if (FinishedRotating ())
		{
			gameObject.GetComponent<AutoMoveAndRotate> ().enabled = false;
			gameObject.transform.eulerAngles = new Vector3 (0, 180, 180);
			gameObject.GetComponent<Rotate> ().enabled = false;
			gameObject.transform.GetChild (0).GetComponent<Move> ().enabled = true;
		}
	}

	private bool FinishedRotating()
	{
		return gameObject.transform.rotation.eulerAngles.x <= 3 &&
			   gameObject.transform.rotation.eulerAngles.x > 0 && 
			   gameObject.transform.rotation.eulerAngles.y == 180 && 
			   gameObject.transform.rotation.eulerAngles.z == 180;
	}*/
}
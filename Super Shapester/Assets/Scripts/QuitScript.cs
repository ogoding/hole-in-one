using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour 
{
	public void Quit ()
	{
		Application.Quit ();
		Debug.Log ("Tried to quit in editor.");
	}
}

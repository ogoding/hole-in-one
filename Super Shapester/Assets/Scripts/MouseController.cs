using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour 
{
	void Start ()
	{
		ShowMouse ();
	}

	void Update () 
	{
	
	}

	public void HideMouse ()
	{
		Cursor.visible = false;
	}

	public void ShowMouse ()
	{
		Cursor.visible = true;
	}
}

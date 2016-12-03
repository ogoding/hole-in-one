using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Application.targetFrameRate = -1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time.fixedDeltaTime = Time.timeScale * 0.016f;
	}
}
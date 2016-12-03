using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

	public Camera camera;
	public float shake = 0.0f;
	public float shakeIntensity;
	public float decreaseIntensityBy;

	// Use this for initialization
	void Start ()
	{
		shakeIntensity = 0.5f;
		decreaseIntensityBy = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.R))
			shake = 1.0f;
		if (shake > 0)
		{
			camera.transform.localPosition = Random.insideUnitSphere * shakeIntensity;
			shake -= Time.deltaTime * decreaseIntensityBy;
		} 
		else
		{
			shake = 0.0f;
		}
	}
}
using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

	public Camera camera;
	public float shakeIntensity = 0.0f;
	public float decreaseIntensityBy;

	// Use this for initialization
	void Start ()
	{
		decreaseIntensityBy = 0.01f;
	}

	public void ShakeScreen(float intensity)
	{
		shakeIntensity = intensity;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shakeIntensity > 0)
		{
			camera.transform.localPosition = Random.insideUnitSphere * shakeIntensity;
			shakeIntensity -= decreaseIntensityBy;
		} 
		else
		{
			shakeIntensity = 0.0f;
		}
	}


}
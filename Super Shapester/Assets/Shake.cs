using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
	public Camera cam;
	public float shakeIntensity = 0.0f;
	public float decreaseIntensityBy;

	void Start ()
	{
		decreaseIntensityBy = 0.01f;
	}

	public void ShakeScreen (float intensity)
	{
		shakeIntensity = intensity;
	}

	void Update () 
	{
		if (shakeIntensity > 0)
		{
			cam.transform.localPosition = Random.insideUnitSphere * shakeIntensity;
			
			shakeIntensity -= decreaseIntensityBy;
		} 
		else
		{
			shakeIntensity = 0.0f;
		}
	}
}
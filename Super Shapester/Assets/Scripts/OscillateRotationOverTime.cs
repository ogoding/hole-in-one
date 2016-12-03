using UnityEngine;
using System.Collections;

public class OscillateRotationOverTime : MonoBehaviour 
{
	public Vector3 rotationAmount;
	public float sinPhase;
	public Vector3 rotationFrequency;
	public Vector3 offset;
	public bool assignRandom;
	public Vector2 RandomAmount;

	void Start ()
	{
		if (assignRandom == true) 
		{
			rotationAmount = new Vector3 (Random.Range (-RandomAmount.x, RandomAmount.x), Random.Range (-RandomAmount.x, RandomAmount.x), Random.Range (-RandomAmount.x, RandomAmount.x));
			rotationFrequency = new Vector3 (Random.Range (-RandomAmount.y, RandomAmount.y), Random.Range (-RandomAmount.y, RandomAmount.y), Random.Range (-RandomAmount.y, RandomAmount.y));
		}
	}

	void Update () 
	{
		sinPhase += Time.deltaTime;

		transform.rotation = Quaternion.Euler 
			(
				(rotationAmount.x * Mathf.Sin(sinPhase * rotationFrequency.x ) + offset.x),
				(rotationAmount.y * Mathf.Sin(sinPhase * rotationFrequency.y ) + offset.y),
				(rotationAmount.z * Mathf.Sin(sinPhase * rotationFrequency.z ) + offset.z)
			);
	}
}

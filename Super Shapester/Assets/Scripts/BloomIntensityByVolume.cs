using UnityEngine;
using System.Collections;
using UnityStandardAssets.CinematicEffects;

public class BloomIntensityByVolume : MonoBehaviour 
{
	public AudioSource Audio;
	public Bloom bloomScript;
	public Vector2 Limits;
	public float offset;

	void Start () 
	{
	
	}

	void Update ()
	{
		bloomScript.settings.intensity = Mathf.Clamp(Audio.GetComponent<AudioSourceLoudnessTester>().clipLoudness, Limits.x, Limits.y) + offset;
	}
}

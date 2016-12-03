using UnityEngine;
using System.Collections;

public class AudioPitchByTimescale : MonoBehaviour 
{
	public AudioSource Audio;
	public float AddPitch;
	public float AmpPitch;

	void Start ()
	{
		if (Audio == null) 
		{
			Audio = GetComponent<AudioSource> ();
		}
	}

	void Update () 
	{
		Audio.pitch = (AmpPitch * Time.timeScale) + AddPitch;
	}
}

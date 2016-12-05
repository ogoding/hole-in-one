using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioPitchByTimescale : MonoBehaviour 
{
	public AudioSource Audio;
	public float AddPitch;
	public float AmpPitch = 1.0f;
	public bool TestMode;
	public float increasePitchRate;

	void Start ()
	{
		Time.timeScale = 1;
		if (Audio == null) 
		{
			Audio = GetComponent<AudioSource> ();
		}
	}

	void Update () 
	{
		if (TestMode == false) 
		{
			Audio.pitch = (AmpPitch * Time.timeScale) + AddPitch;
		}

		if (TestMode == true) 
		{
			Audio.pitch += increasePitchRate;
		}
	}
}

using UnityEngine;
using System.Collections;

public class DestroyOrDeactivateOverTime : MonoBehaviour 
{
	public enum type
	{
		Destroy,
		Deactivate
	}

	public type DestroyType;

	public float timeDuration;
	public float timeRemaining;

	void Start ()
	{
		timeRemaining = timeDuration;

		if (DestroyType == type.Destroy) 
		{
			Destroy (gameObject, timeDuration);
		}
	}

	void Update ()
	{
		if (DestroyType == type.Deactivate) 
		{
			timeRemaining -= Time.unscaledDeltaTime;
			if (timeRemaining < 0) 
			{
				GetComponent<DestroyOrDeactivateOverTime> ().enabled = false;
				gameObject.SetActive (false);
			}
		}
	}
}
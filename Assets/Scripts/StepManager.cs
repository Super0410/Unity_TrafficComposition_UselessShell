using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{

	public static StepManager _instance;

	public event System.Action OnVideoStart;
	public event System.Action OnVideoEnd;

	void Awake ()
	{
		_instance = this;
	}

	public void NotifyVideoStart ()
	{
		if (OnVideoStart != null) {
			OnVideoStart ();
		}
	}

	public void NotifyVideoEnd ()
	{
		if (OnVideoEnd != null) {
			OnVideoEnd ();
		}
	}
}

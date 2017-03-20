using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficEnableManager : MonoBehaviour
{
	public GameObject GenerateParent;

	void Start ()
	{
		StepManager._instance.OnVideoEnd += enableTraffic;
		StepManager._instance.OnVideoStart += disableTraffic;
	}

	void enableTraffic ()
	{
		GenerateParent.SetActive (true);
	}

	void disableTraffic ()
	{
		GenerateParent.SetActive (false);
	}
}

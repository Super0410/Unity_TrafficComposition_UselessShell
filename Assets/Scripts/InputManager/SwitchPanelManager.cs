using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanelManager : MonoBehaviour
{
	public GameObject Panel_Unknown;
	public GameObject Panel_Detected;

	void Start ()
	{
		StepManager._instance.OnVideoStart += update2Unknown;
		StepManager._instance.OnVideoEnd += updateQuality;
	}

	void update2Unknown ()
	{
		if (Panel_Unknown != null)
			Panel_Unknown.SetActive (true);
		if (Panel_Detected != null)
			Panel_Detected.SetActive (false);
	}

	void updateQuality ()
	{
		if (Panel_Unknown != null)
			Panel_Unknown.SetActive (false);
		if (Panel_Detected != null)
			Panel_Detected.SetActive (true);
	}
}

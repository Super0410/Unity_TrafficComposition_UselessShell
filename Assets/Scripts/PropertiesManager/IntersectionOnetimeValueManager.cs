using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntersectionOnetimeValueManager : MonoBehaviour
{

	public Text Text_QueueLength;
	public Text Text_Delay;
	public Text Text_Traffic;
	public Text Text_Velocity;

	public IntersectionValues intersectionValues;

	public string QueueUnit = "m";
	public string DelayUnit = "s";
	public string TrafficUnit = "辆/h";
	public string VelocityUnit = "m/s";

	void Start ()
	{
		//TODO
		StepManager._instance.OnVideoEnd += updateIntersectionUI;
	}

	void updateIntersectionUI ()
	{
		Text_QueueLength.text = intersectionValues.QueueLength.ToString () + QueueUnit;
		Text_Delay.text = intersectionValues.Delay.ToString () + DelayUnit;
		Text_Traffic.text = intersectionValues.Traffic.ToString () + TrafficUnit;
		Text_Velocity.text = intersectionValues.Velocity.ToString () + VelocityUnit;
	}
}

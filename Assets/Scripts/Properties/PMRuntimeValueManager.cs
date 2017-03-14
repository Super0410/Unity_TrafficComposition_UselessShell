using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMRuntimeValueManager : MonoBehaviour
{
	public Text Text_PM;

	public float PrePM;
	public string PMPrefix = "PM:";
	public string PMUnit;
	public float RandomTime;
	public float RandomScale;

	RandomUtil randomUtil;

	void Start ()
	{
		randomUtil = new RandomUtil ();

		//TODO
	}

	void randomValue ()
	{
		StartCoroutine (randomUtil.randomValue (PrePM, Text_PM, PMUnit, RandomTime, RandomScale, PMPrefix));
	}

	void stopRandom ()
	{
		StopAllCoroutines ();
	}
}

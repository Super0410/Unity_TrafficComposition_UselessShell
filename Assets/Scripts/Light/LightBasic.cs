using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBasic : MonoBehaviour
{
	Collider[] carWaitColliderArr;
	float yellowTime;

	void Start ()
	{
		carWaitColliderArr = GetComponentsInChildren<Collider> ();
		setTriggerEnable (false);

		yellowTime = LightController._instance.YellowTime;
	}

	public void notifyStop ()
	{
		//TODO
		setTriggerEnable (true);
	}

	public void notifyMove ()
	{
		StartCoroutine (letVehicalMove ());
	}

	IEnumerator letVehicalMove ()
	{
		yield return new WaitForSeconds (yellowTime);
		//TODO
		setTriggerEnable (false);
	}

	void setTriggerEnable (bool isEnable)
	{
		for (int i = 0; i < carWaitColliderArr.Length; i++) {
			carWaitColliderArr [i].enabled = isEnable;
		}
	}
}

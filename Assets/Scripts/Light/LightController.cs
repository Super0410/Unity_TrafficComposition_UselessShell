using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
	public static LightController _instance;

	public float SwitchTime = 20f;
	public float YellowTime = 2f;

	public LightBasic horiLight;
	public LightBasic vertLight;

	public delegate void OnMove (bool isHorizontal);

	public OnMove OnMoveHandler;

	void Awake ()
	{
		_instance = this;
	}

	void Start ()
	{
		StartCoroutine (changeLight ());
	}

	IEnumerator changeLight ()
	{
		horiLight.notifyMove ();
		vertLight.notifyStop ();
		StartCoroutine (notifyMove (true));
		yield return new WaitForSeconds (SwitchTime);

		horiLight.notifyStop ();
		vertLight.notifyMove ();
		StartCoroutine (notifyMove (false));
		yield return new WaitForSeconds (SwitchTime);
		StartCoroutine (changeLight ());
	}

	IEnumerator notifyMove (bool isHorizontal)
	{
		yield return new WaitForSeconds (YellowTime);
		if (OnMoveHandler != null)
			OnMoveHandler (isHorizontal);
	}
}
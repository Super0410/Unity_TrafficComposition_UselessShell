using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueToothInputManager : MonoBehaviour
{
	public Button Btn_Connected;
	public Text Text_BlueToothConnected;

	public delegate void OnBlueToothConnected ();

	public OnBlueToothConnected OnBlueToothConnectedHandler;

	void Start ()
	{
		Btn_Connected.onClick.AddListener (delegate {
			onBtnConnectedClicked ();
		});

		Text_BlueToothConnected.enabled = false;
	}

	void onBtnConnectedClicked ()
	{
		Text_BlueToothConnected.enabled = true;

		if (OnBlueToothConnectedHandler != null)
			OnBlueToothConnectedHandler ();
	}
}
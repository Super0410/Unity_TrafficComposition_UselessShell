using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueToothInputManager : MonoBehaviour
{
	public Button Btn_Connected;
	public GameObject Panel_Connecting;
	public Text Text_BlueToothConnected;
	public float ConnectingTime = 1.5f;

	bool isConnected = false;

	public delegate void OnBlueToothConnected ();

	public OnBlueToothConnected OnBlueToothConnectedHandler;

	void Start ()
	{
		Btn_Connected.onClick.AddListener (delegate {
			onBtnConnectedClicked ();
		});

		Panel_Connecting.SetActive (false);
		Text_BlueToothConnected.enabled = false;
	}

	void onBtnConnectedClicked ()
	{
		if (isConnected)
			return;
		
		StartCoroutine (connectBlueTooth ());
		isConnected = true;
	}

	IEnumerator connectBlueTooth ()
	{
		Panel_Connecting.SetActive (true);

		yield return new WaitForSeconds (ConnectingTime);
		Panel_Connecting.SetActive (false);
		Text_BlueToothConnected.enabled = true;

		if (OnBlueToothConnectedHandler != null)
			OnBlueToothConnectedHandler ();
	}
}
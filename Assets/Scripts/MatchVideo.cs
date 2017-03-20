using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchVideo : MonoBehaviour
{
	//firestly this is a mess
	//it will be better with dictionary or hash or sth can use reflect
	//but im too tired today, so .........................

	public Button Btn_EastClip;
	public Button Btn_SouthClip;
	public Button Btn_NorthClip;
	public Button Btn_WestClip;

	Image Image_EastClip;
	Image Image_SouthClip;
	Image Image_NorthClip;
	Image Image_WestClip;

	public Button Btn_EastHolder;
	public Button Btn_SouthHolder;
	public Button Btn_NorthHolder;
	public Button Btn_WestHolder;

	Image Image_EastHolder;
	Image Image_SouthHolder;
	Image Image_NorthHolder;
	Image Image_WestHolder;

	public Image Blender_VideoPlayer;

	Button Btn_Play;

	int clipHoldedCounter = 0;

	void Start ()
	{
		//Clip from device
		Btn_EastClip.onClick.AddListener (delegate {
			onClickVideoClip ("East");
		});
		Btn_SouthClip.onClick.AddListener (delegate {
			onClickVideoClip ("South");
		});
		Btn_NorthClip.onClick.AddListener (delegate {
			onClickVideoClip ("North");
		});
		Btn_WestClip.onClick.AddListener (delegate {
			onClickVideoClip ("West");
		});


		Image_EastClip = Btn_EastClip.transform.FindChild ("Bg").GetComponent<Image> ();
		Image_SouthClip = Btn_SouthClip.transform.FindChild ("Bg").GetComponent<Image> ();
		Image_NorthClip = Btn_NorthClip.transform.FindChild ("Bg").GetComponent<Image> ();
		Image_WestClip = Btn_WestClip.transform.FindChild ("Bg").GetComponent<Image> ();


		//Holder
		Btn_EastHolder.onClick.AddListener (delegate {
			onClickVideoContainer ("East");
		});
		Btn_SouthHolder.onClick.AddListener (delegate {
			onClickVideoContainer ("South");
		});
		Btn_NorthHolder.onClick.AddListener (delegate {
			onClickVideoContainer ("North");
		});
		Btn_WestHolder.onClick.AddListener (delegate {
			onClickVideoContainer ("West");
		});

		Image_EastHolder = Btn_EastHolder.transform.FindChild ("VideoClip").GetComponent<Image> ();
		Image_SouthHolder = Btn_SouthHolder.transform.FindChild ("VideoClip").GetComponent<Image> ();
		Image_NorthHolder = Btn_NorthHolder.transform.FindChild ("VideoClip").GetComponent<Image> ();
		Image_WestHolder = Btn_WestHolder.transform.FindChild ("VideoClip").GetComponent<Image> ();

		Image_EastHolder.enabled = false;
		Image_SouthHolder.enabled = false;
		Image_NorthHolder.enabled = false;
		Image_WestHolder.enabled = false;


		//Final play button
		Blender_VideoPlayer.gameObject.SetActive (false);
		Btn_Play = Blender_VideoPlayer.GetComponentInChildren<Button> ();
		Btn_Play.onClick.AddListener (delegate {
			notifyVideoBegin ();
		});
	}

	void onClickVideoContainer (string videoDirType)
	{
		if (videoDirType == "East") {
			Btn_EastClip.enabled = true;
			Btn_SouthClip.enabled = false;
			Btn_NorthClip.enabled = false;
			Btn_WestClip.enabled = false;

			Image_EastClip.enabled = true;
			Image_SouthClip.enabled = false;
			Image_NorthClip.enabled = false;
			Image_WestClip.enabled = false;
		} else if (videoDirType == "South") {
			Btn_EastClip.enabled = false;
			Btn_SouthClip.enabled = true;
			Btn_NorthClip.enabled = false;
			Btn_WestClip.enabled = false;

			Image_EastClip.enabled = false;
			Image_SouthClip.enabled = true;
			Image_NorthClip.enabled = false;
			Image_WestClip.enabled = false;
		} else if (videoDirType == "North") {
			Btn_EastClip.enabled = false;
			Btn_SouthClip.enabled = false;
			Btn_NorthClip.enabled = true;
			Btn_WestClip.enabled = false;

			Image_EastClip.enabled = false;
			Image_SouthClip.enabled = false;
			Image_NorthClip.enabled = true;
			Image_WestClip.enabled = false;
		} else if (videoDirType == "West") {
			Btn_EastClip.enabled = false;
			Btn_SouthClip.enabled = false;
			Btn_NorthClip.enabled = false;
			Btn_WestClip.enabled = true;

			Image_EastClip.enabled = false;
			Image_SouthClip.enabled = false;
			Image_NorthClip.enabled = false;
			Image_WestClip.enabled = true;
		}
	}

	void onClickVideoClip (string videoDirType)
	{
		if (videoDirType == "East") {
			if (Image_EastHolder.enabled == false) {
				Image_EastHolder.enabled = true;
				clipCounter ();
			}

		} else if (videoDirType == "South") {
			if (Image_SouthHolder.enabled == false) {
				Image_SouthHolder.enabled = true;
				clipCounter ();
			}

		} else if (videoDirType == "North") {
			if (Image_NorthHolder.enabled == false) {
				Image_NorthHolder.enabled = true;
				clipCounter ();
			}

		} else if (videoDirType == "West") {
			if (Image_WestHolder.enabled == false) {
				Image_WestHolder.enabled = true;
				clipCounter ();
			}
		}
	}

	void clipCounter ()
	{
		clipHoldedCounter++;
		if (clipHoldedCounter >= 4) {
			Blender_VideoPlayer.gameObject.SetActive (true);
		}
	}

	void notifyVideoBegin ()
	{
		StepManager._instance.NotifyVideoStart ();
	}
}
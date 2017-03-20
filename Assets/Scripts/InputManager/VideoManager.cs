using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
	//	/*
	public GameObject CCTVParent;
	public float VideoLength = 30;
	
	MediaPlayerCtrl[] videoPlayerArr;

	bool isVideoPlaying = false;

	void Start ()
	{
		videoPlayerArr = CCTVParent.GetComponentsInChildren<MediaPlayerCtrl> ();
	
		StepManager._instance.OnVideoStart += PlayVideo;
	}

	public void PlayVideo ()
	{
		if (isVideoPlaying)
			return;
	
		for (int i = 0; i < videoPlayerArr.Length; i++) {
			videoPlayerArr [i].Play ();
		}
		isVideoPlaying = true;
	
		StartCoroutine (wait4Video ());

		StepManager._instance.NotifyVideoStart ();
	}

	public void StopVideo ()
	{
		if (!isVideoPlaying)
			return;
	
		for (int i = 0; i < videoPlayerArr.Length; i++) {
			videoPlayerArr [i].Stop ();
		}
		isVideoPlaying = false;

		StopAllCoroutines ();
	
		StepManager._instance.NotifyVideoEnd ();
	}

	IEnumerator wait4Video ()
	{
		yield return new WaitForSeconds (VideoLength);
		StopVideo ();
	}
	//	*/
}
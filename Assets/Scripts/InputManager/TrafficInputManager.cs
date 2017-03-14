using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrafficInputManager : MonoBehaviour
{
	public PanelMaximum TrafficPanelDrager;
	public Transform cameraCenter;

	bool isTrafficDraging = false;
	bool isDrag = false;
	float mouseSpeedX;
	float mouseSpeedY;
	float rotateX;

	public float scaleMin = 30f;
	public float scaleMax = 65f;
	Transform cameraTrans;
	float cameraZoom = 30f;

	void Start ()
	{
		TrafficPanelDrager.OnPanelDragedHandler += onTrafficPanelDrager;
		TrafficPanelDrager.OnPanelPointerUpHandler += onTrafficPanelPointerUp;
		TrafficPanelDrager.OnPanelEndDragedHandler += onTrafficPanelEndDrag;

		cameraTrans = cameraCenter.GetComponentInChildren<Camera> ().transform;
	}

	void Update ()
	{
		trafficDrag ();
	}

	void onTrafficPanelEndDrag ()
	{
		isTrafficDraging = false;
	}

	void onTrafficPanelDrager ()
	{
		isTrafficDraging = true;
	}

	void onTrafficPanelPointerUp ()
	{
		isTrafficDraging = false;
	}

	void  trafficDrag ()
	{
		if (isTrafficDraging) {
			if (Input.touchCount == 1) {//&& !isMultiEnd) {
				if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					isDrag = true;
				} else
					isDrag = false;
			} else
				isDrag = false;

			if (isDrag) {
				mouseSpeedY = Mathf.Lerp (mouseSpeedY, -5 * Input.GetAxis ("Mouse X") / Time.deltaTime, 8f * Time.deltaTime);
			} else {
				mouseSpeedY = Mathf.Lerp (mouseSpeedY, 0, 5f * Time.deltaTime);
			}

//			MultiTouchZoomCamera ();
		}
		mouseSpeedY = Mathf.Lerp (mouseSpeedY, 0, 5f * Time.deltaTime);

		cameraCenter.Rotate (Vector3.down, Time.deltaTime * mouseSpeedY);

//		cameraTrans.position = Vector3.Lerp (cameraTrans.position, cameraCenter.position - cameraZoom * cameraTrans.forward, 8f * Time.deltaTime);
	}

	bool isMultiEnd = false;

	Vector2 lastPos1;
	Vector2 lastPos2;

	void MultiTouchZoomCamera ()
	{
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				isMultiEnd = false;
			}
		}

		if (Input.touchCount < 2) {  
			return;  
		}

		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				lastPos1 = Input.GetTouch (0).position;  
				lastPos2 = Input.GetTouch (1).position;  
				return;  
			}
		}

		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Ended) {
				isMultiEnd = true;
			}
		}

		if (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved) {

			float oldDistance = Vector2.Distance (lastPos1, lastPos2);  
			float newDistance = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);  

			float offset = newDistance - oldDistance;  

			cameraZoom += -offset / 30f;
			cameraZoom = Mathf.Clamp (cameraZoom, scaleMin, scaleMax);

			lastPos1 = Input.GetTouch (0).position;  
			lastPos2 = Input.GetTouch (1).position;  
		}
	}
}

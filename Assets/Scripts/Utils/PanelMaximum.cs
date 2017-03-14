using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelMaximum : MonoBehaviour,IPanelCanMaximum,IPointerDownHandler,IPointerUpHandler,IDragHandler,IEndDragHandler
{

	public delegate void OnPanelDraged ();

	public OnPanelDraged OnPanelDragedHandler;

	public delegate void OnPanelEndDraged ();

	public OnPanelEndDraged OnPanelEndDragedHandler;

	public delegate void OnPanelPointerUp ();

	public OnPanelDraged OnPanelPointerUpHandler;

	public delegate void OnPanelMinimum ();

	public OnPanelDraged OnPanelMinimumHandler;

	Button btn_Minimum;
	bool hasDrag = false;

	void Start ()
	{
		btn_Minimum = transform.FindChild ("Btn_Minimum").GetComponent<Button> ();
		btn_Minimum.onClick.AddListener (delegate {
			DoMinimum ();	
		});
	}

	public void DoMinimum ()
	{
		GetComponent<Animator> ().SetBool ("IsMax", false);

		if (OnPanelMinimumHandler != null)
			OnPanelMinimumHandler ();
	}

	public void DoMaximum ()
	{
		transform.SetAsLastSibling ();
		GetComponent<Animator> ().SetBool ("IsMax", true);
	}

	public void OnDrag (PointerEventData eventData)
	{
		hasDrag = true;
		if (OnPanelDragedHandler != null)
			OnPanelDragedHandler ();
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		if (OnPanelEndDragedHandler != null)
			OnPanelEndDragedHandler ();
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		hasDrag = false;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		if (hasDrag) {
			hasDrag = false;
			return;
		} else {
			DoMaximum ();
		}

		if (OnPanelPointerUpHandler != null)
			OnPanelPointerUpHandler ();
		
	}
}

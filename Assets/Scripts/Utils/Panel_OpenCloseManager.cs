using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_OpenCloseManager : MonoBehaviour
{
	public void doOpen (Animator targetAnimator)
	{
		targetAnimator.SetBool ("IsMax", true);
		targetAnimator.transform.SetAsLastSibling ();
	}

	public void doClose (Animator targetAnimator)
	{
		targetAnimator.SetBool ("IsMax", false);
	}
}

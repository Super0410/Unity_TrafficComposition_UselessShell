using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityCircle : MonoBehaviour
{

	public Transform QualityOutter;
	public Transform QualityInner;

	public float RotateSpeed = 10;

	void Update ()
	{
		QualityOutter.eulerAngles += new Vector3 (0, 0, RotateSpeed) * Time.deltaTime;
		QualityInner.eulerAngles -= new Vector3 (0, 0, RotateSpeed) * Time.deltaTime;
	}
}

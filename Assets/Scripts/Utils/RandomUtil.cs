using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomUtil //: MonoBehaviour
{
	public IEnumerator randomValue (float preTarget, Text uiTarget, string unit, float changeTime, float randomScale, string prefix = "")
	{
		while (true) {

			int randomValue = (int)Random.Range (-randomScale * 10, randomScale * 10);
			float finalValue = preTarget + (float)randomValue / 10;

			uiTarget.text = prefix + finalValue.ToString () + unit;

			float randomTime = Random.Range (-1, 1);
			yield return new WaitForSeconds (changeTime + randomTime);

		}
	}
}

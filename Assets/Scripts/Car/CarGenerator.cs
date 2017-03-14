using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
	public Transform generatRateTrans;
	public GameObject[] carPrefabsArr;
	public bool isGenerateHorizontal;

	GenerateProperties generateProperties;

	void Start ()
	{
		generateProperties = GetComponentInParent<GenerateProperties> ();
		StartCoroutine (generatTimer ());
	}

	IEnumerator generatTimer ()
	{
		generateOneCar ();

		float timerOffset = Random.Range (-1, 1);
		yield return new WaitForSeconds (generateProperties.generateRate + timerOffset);

		StartCoroutine (generatTimer ());
	}

	void generateOneCar ()
	{
		int carIndex = Random.Range (0, carPrefabsArr.Length);
		GameObject oneCar = (GameObject)Instantiate (carPrefabsArr [carIndex], transform.position, transform.rotation);
		oneCar.GetComponent<CarMovement> ().isHorizontal = isGenerateHorizontal;
		oneCar.GetComponent<CarMovement> ().preSpeed = generateProperties.carSpeed;
		oneCar.GetComponent<CarMovement> ().curAcceleration = generateProperties.carAcceleration;
	}
}

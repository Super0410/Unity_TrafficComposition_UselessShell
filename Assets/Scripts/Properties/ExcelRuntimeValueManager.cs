using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcelRuntimeValueManager : MonoBehaviour
{
	public Text Text_Polution_NOx;
	public Text Text_Polution_HC;
	public Text Text_Polution_SO2;
	public Text Text_Polution_Oil;
	public Text Text_Polution_PM25;
	public Text Text_Polution_PM10;
	public Text Text_Polution_CO;

	public Text Text_Density_NOx;
	public Text Text_Density_HC;
	public Text Text_Density_SO2;
	public Text Text_Density_PM25;
	public Text Text_Density_PM10;
	public Text Text_Density_Noise;
	public Text Text_Density_CO;

	public string PolutionUnit = "g/h";
	public string DensityUnit = "μg/m^3";
	
	public ExcelRuntimeValues excelPreValues;

	public float RandomScale_Polution_NOx = 3;
	public float RandomScale_Polution_HC = 3;
	public float RandomScale_Polution_SO2 = 3;
	public float RandomScale_Polution_Oil = 3;
	public float RandomScale_Polution_PM25 = 3;
	public float RandomScale_Polution_PM10 = 3;
	public float RandomScale_Polution_CO = 3;

	public float RandomScale_Density_NOx = 3;
	public float RandomScale_Density_HC = 3;
	public float RandomScale_Density_SO2 = 3;
	public float RandomScale_Density_PM25 = 3;
	public float RandomScale_Density_PM10 = 3;
	public float RandomScale_Density_Noise = 3;
	public float RandomScale_Density_CO = 3;

	public float changeTime = 3;

	RandomUtil randomUtil;

	void Start ()
	{
		randomUtil = new RandomUtil ();

		//TODO
	}

	void startRandomExcel ()
	{
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_NOx, Text_Polution_NOx, PolutionUnit, changeTime, RandomScale_Polution_NOx));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_HC, Text_Polution_HC, PolutionUnit, changeTime, RandomScale_Polution_HC));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_SO2, Text_Polution_SO2, PolutionUnit, changeTime, RandomScale_Polution_SO2));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_Oil, Text_Polution_Oil, PolutionUnit, changeTime, RandomScale_Polution_Oil));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_PM25, Text_Polution_PM25, PolutionUnit, changeTime, RandomScale_Polution_PM25));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_PM10, Text_Polution_PM10, PolutionUnit, changeTime, RandomScale_Polution_PM10));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Polution_CO, Text_Polution_CO, PolutionUnit, changeTime, RandomScale_Polution_CO));

		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_NOx, Text_Density_NOx, DensityUnit, changeTime, RandomScale_Density_NOx));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_HC, Text_Density_HC, DensityUnit, changeTime, RandomScale_Density_HC));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_SO2, Text_Density_SO2, DensityUnit, changeTime, RandomScale_Density_SO2));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_PM25, Text_Density_PM25, DensityUnit, changeTime, RandomScale_Density_PM25));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_PM10, Text_Density_PM10, DensityUnit, changeTime, RandomScale_Density_PM10));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_Noise, Text_Density_Noise, DensityUnit, changeTime, RandomScale_Density_Noise));
		StartCoroutine (randomUtil.randomValue (excelPreValues.Density_CO, Text_Density_CO, DensityUnit, changeTime, RandomScale_Density_CO));
	}

	void stopRandomExcel ()
	{
		StopAllCoroutines ();
	}
}


[System.Serializable]
public struct ExcelRuntimeValues
{
	public float Polution_NOx;
	public float Polution_HC;
	public float Polution_SO2;
	public float Polution_Oil;
	public float Polution_PM25;
	public float Polution_PM10;
	//	public float Polution_Noise;
	public float Polution_CO;

	public float Density_NOx;
	public float Density_HC;
	public float Density_SO2;
	//	public float Density_Oil;
	public float Density_PM25;
	public float Density_PM10;
	public float Density_Noise;
	public float Density_CO;
}

[System.Serializable]
public struct IntersectionValues
{
	public float QueueLength;
	public float Delay;
	public float Traffic;
	public float Velocity;
}

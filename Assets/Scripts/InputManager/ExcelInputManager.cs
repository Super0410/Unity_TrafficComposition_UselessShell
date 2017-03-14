using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcelInputManager : MonoBehaviour
{
	public PanelMaximum ExcelPanelHandler;

	GridLayoutGroup[] canMaximumLayoutArr;
	public float minCellX = 180;
	public float maxCellX = 380;

	void Start ()
	{
		ExcelPanelHandler.OnPanelPointerUpHandler += onExcelPanelPointerUp;
		ExcelPanelHandler.OnPanelMinimumHandler += onExcelPanelMinimum;

		canMaximumLayoutArr = ExcelPanelHandler.GetComponentsInChildren<GridLayoutGroup> ();
	}

	void onExcelPanelPointerUp ()
	{
		for (int i = 0; i < canMaximumLayoutArr.Length; i++) {
			canMaximumLayoutArr [i].cellSize = new Vector2 (maxCellX, 100);
		}
	}

	void onExcelPanelMinimum ()
	{
		for (int i = 0; i < canMaximumLayoutArr.Length; i++) {
			canMaximumLayoutArr [i].cellSize = new Vector2 (minCellX, 100);
		}
	}

}

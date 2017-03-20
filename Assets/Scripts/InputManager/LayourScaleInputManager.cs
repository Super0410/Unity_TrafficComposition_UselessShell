using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayourScaleInputManager : MonoBehaviour
{
	public PanelMaximum LayoutPanelHandler;

	GridLayoutGroup[] canMaximumLayoutArr;
	public float minCellX = 180;
	public float maxCellX = 380;
	public float minCellY = 100;
	public float maxCellY = 100;

	void Start ()
	{
		LayoutPanelHandler.OnPanelPointerUpHandler += onExcelPanelPointerUp;
		LayoutPanelHandler.OnPanelMinimumHandler += onExcelPanelMinimum;

		canMaximumLayoutArr = LayoutPanelHandler.GetComponentsInChildren<GridLayoutGroup> ();
	}

	void onExcelPanelPointerUp ()
	{
		for (int i = 0; i < canMaximumLayoutArr.Length; i++) {
			canMaximumLayoutArr [i].cellSize = new Vector2 (maxCellX, maxCellY);
		}
	}

	void onExcelPanelMinimum ()
	{
		for (int i = 0; i < canMaximumLayoutArr.Length; i++) {
			canMaximumLayoutArr [i].cellSize = new Vector2 (minCellX, minCellY);
		}
	}

}

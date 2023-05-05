using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HexMapEditor : MonoBehaviour
{
	public Renderer rend;
	public ToggleGroup toggleGroup;
	public HexCell selectedCell;
	public int[] buildings;
	public HexGrid hexGrid;
	private int activeBuilding;

	void Awake()
	{
		SelectColor(0);
	}
	void Update()
	{
		if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			HandleInput();
		}
	}
	void HandleInput()
	{
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (toggleGroup.AnyTogglesOn())
		{
			if (Physics.Raycast(inputRay, out hit))
			{
				//put 2 random numbers to leave without error code
				hexGrid.ChooseBuilding(5, 5, activeBuilding);
			}
		}
	}
	public void SelectColor(int index)
	{
		activeBuilding = buildings[index];
	}
}
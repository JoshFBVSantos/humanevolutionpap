using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettlerScript : MonoBehaviour
{
    public int maxMP;
    public int currentMP;
    public int id;
    public GameObject settlerUI;
    public HexGrid hexGrid;
    public void Start()
    {
        currentMP = maxMP;
        hexGrid = GameObject.Find("Hex Grid").GetComponent<HexGrid>();
        id = hexGrid.settlersTrained;
        settlerUI = GetComponentInChildren<Canvas>().gameObject;
        settlerUI.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            WhenClicked();
        }
    }
    public void WhenClicked()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            if (hit.transform.GetComponentInChildren<SettlerScript>() != null)
            {
                if (hit.transform.GetComponentInChildren<SettlerScript>().id == id)
                {
                    settlerUI.SetActive(true);
                }
            }
            else
            {
                settlerUI.SetActive(false);
            }
        }
    }
    public void BuildCC()
    {
        hexGrid.ChooseBuilding(this.GetComponentInParent<UnitMovement>().startingCell.coordinates.X, this.GetComponentInParent<UnitMovement>().startingCell.coordinates.Y, 1);
        foreach(GameObject btn in this.GetComponentInParent<UnitMovement>().btns)
        {
            Destroy(btn);
        }
        settlerUI.SetActive(false);
        hexGrid.settlers.Remove(this.gameObject);
        this.transform.DetachChildren();
        Destroy(this.gameObject);
    }
}

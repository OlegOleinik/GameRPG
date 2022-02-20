using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCellsPanel : MonoBehaviour
{
    private MagicCell[] magicCells;
    public MagicCell selectedCell = null;
    private KeyCode[] numberKeys = new KeyCode[] { KeyCode.Alpha1,
    KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
    //
    //
    //
    //DELITE AFTER TESTS
    [SerializeField] MagicScriptableObject spell1;
    //*********
    //
    //
    //
    //
    private void Start()
    {
        magicCells = gameObject.GetComponentsInChildren<MagicCell>();
        for (int i = 0; i < magicCells.Length; i++)
        {
            magicCells[i].ClearCell();
            magicCells[i].id = i;
        }
        magicCells[0].DrawCell(spell1);
    }

    private void Update()
    {
        CheckSelectControl();
    }

    private void CheckSelectControl()
    {
        float mouseWheelAxis = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheelAxis != 0 && selectedCell != null)
        {
            if (selectedCell.id==0 && mouseWheelAxis<0)
            {
                ChangeSelected(magicCells[8]);
                return;
            }
            else if (selectedCell.id == 8 && mouseWheelAxis > 0)
            {
                ChangeSelected(magicCells[0]);
                return;
            }
            ChangeSelected(magicCells[selectedCell.id+ System.Convert.ToInt32(mouseWheelAxis)]);
            return;
        }
        int keyKode = CheckNumberDown();
        if (keyKode >= 0)
        {
            ChangeSelected(magicCells[keyKode]);
        }

    }

    private int CheckNumberDown()
    {
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                return i;
            }
        }
        return -1;
    }

    public void ChangeSelected(MagicCell newCell)
    {
        if (selectedCell != null)
        {
            ClearSelected();
        }
        selectedCell = newCell;
        selectedCell.selected = true;
        selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
    }

    public void ClearSelected()
    {
        selectedCell.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
        selectedCell.selected = false;
        selectedCell = null;
    }
}

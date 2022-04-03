using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MagicCellsPanel : MonoBehaviour
{
    private MagicCell[] magicCells;
    public MagicCell selectedCell = null;
    //private KeyCode[] numberKeys = new KeyCode[] { KeyCode.Alpha1,
    //KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
    private GameObject activeSpell;
    private Player player;
    [SerializeField] MagicUpPanel magicUpPanel;
    //
    //
    //
    //DELITE AFTER TESTS
    [SerializeField] MagicScriptableObject spell1;
    [SerializeField] MagicScriptableObject spell2;
    [SerializeField] MagicScriptableObject spell3;
    [SerializeField] MagicScriptableObject spell4;
    //*********
    //
    //
    //
    //
    [SerializeField] Text text;
    bool isDisappearingText = false;
    private float timer;
    private void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        magicCells = gameObject.GetComponentsInChildren<MagicCell>();
        for (int i = 0; i < magicCells.Length; i++)
        {
            magicCells[i].ClearCell();
            magicCells[i].id = i;
        }
        ChangeSelected(magicCells[0]);
        magicCells[0].DrawCell(spell1);
        magicCells[1].DrawCell(spell2);
        magicCells[2].DrawCell(spell3);
        magicCells[3].DrawCell(spell4);
        ShowSpellName();

    }

    private void Update()
    {
      //  CheckSelectControl();
    }

    public int GetSpellLvl(MagicScriptableObject spell)
    {
        return magicUpPanel.GetSpellLvl(spell);
    }
    public float CastSpell()
    {
        if (activeSpell != null && player.currentMagic >= selectedCell.magic.magicCost)
        {
            activeSpell.GetComponent<ASpell>().Spell();
            player.WasteMagic(selectedCell.magic.magicCost + (selectedCell.magic.magicCost * GetSpellLvl(selectedCell.magic) *0.1f));
            return selectedCell.magic.coolDownTime;
        }
        return -1;
    }

    //private void CheckSelectControl()
    //{
    //    //float mouseWheelAxis = Input.GetAxis("Mouse ScrollWheel");
    //    //if (mouseWheelAxis != 0 && selectedCell != null)
    //    //{
    //    //    if (selectedCell.id==0 && mouseWheelAxis<0)
    //    //    {
    //    //        ChangeSelected(magicCells[8]);
    //    //        return;
    //    //    }
    //    //    else if (selectedCell.id == 8 && mouseWheelAxis > 0)
    //    //    {
    //    //        ChangeSelected(magicCells[0]);
    //    //        return;
    //    //    }
    //    //    ChangeSelected(magicCells[selectedCell.id+ System.Convert.ToInt32(mouseWheelAxis)]);
    //    //    return;
    //    //}
    //    //int keyKode = CheckNumberDown();
    //    //if (keyKode >= 0)
    //    //{
    //    //    ChangeSelected(magicCells[keyKode]);
    //    //}

    //}
    public void SetByScroll(InputAction.CallbackContext inputValue)
    {

        float axis = inputValue.ReadValue<float>();
        //Debug.Log(axis);
        if (axis != 0 && selectedCell != null)
        {
            if (selectedCell.id == 0 && axis < 0)
            {
                ChangeSelected(magicCells[8]);
                return;
            }
            else if (selectedCell.id == 8 && axis > 0)
            {
                ChangeSelected(magicCells[0]);
                return;
            }
            ChangeSelected(magicCells[selectedCell.id + (int)axis]);
            return;
        }
    }

    public void SetByNumber(InputAction.CallbackContext inputValue)
    {
        //YourInputAction.YourActionMap.SwitchWeapon.performed += ctx => print(ctx.ReadValue())
        if(inputValue.phase == InputActionPhase.Started)
        {
            ChangeSelected(magicCells[(int)inputValue.ReadValue<float>()]);
        }

        //Keyboard.current. wKey.ReadValue()
        //Debug.Log(((KeyControl)inputValue.control).keyCode);



    }

    //private int CheckNumberDown()
    //{
    //    for (int i = 0; i < numberKeys.Length; i++)
    //    {
    //        if (Input.GetKeyDown(numberKeys[i]))
    //        {
    //            return i;
    //        }
    //    }
    //    return -1;
    //}

    public void ChangeSelected(MagicCell newCell)
    {
        if (selectedCell != null)
        {
            ClearSelected();
            Destroy(activeSpell);
        }
        selectedCell = newCell;
        selectedCell.selected = true;
        selectedCell.SetEnterColor();
        if (selectedCell.magic != null)
        {
            activeSpell = Instantiate(selectedCell.magic.spell.gameObject);
            activeSpell.GetComponent<ASpell>().SetLvl(GetSpellLvl(selectedCell.magic));
            DontDestroyOnLoad(activeSpell);
            //activeSpell.SetActive(false);
        }

        ShowSpellName();
    }

    private void ShowSpellName()
    {
        if (selectedCell.magic != null)
        {
            text.color = new Color(0.196f, 0.196f, 0.196f, 1);
            text.text = selectedCell.magic.spellName;
            timer = Time.time + 2;
            if (!isDisappearingText)
            {
                StartCoroutine(DisappearText());
                //StartCoroutine(2f.Tweeng( (u) => text.color = new Color(0,0,0,u), 1f, 0f));
            }

        }
    }


    public void ClearSelected()
    {
        selectedCell.SetDefaultColor();
        selectedCell.selected = false;
        selectedCell = null;
    }


    IEnumerator DisappearText()
    {
        isDisappearingText = true;
        while (timer > Time.time)
        {
            text.color -= new Color(0, 0, 0, 0.8f * Time.deltaTime);
            yield return null;
        }
        text.color = new Color(0, 0, 0, 0);
        isDisappearingText = false;
    }
}

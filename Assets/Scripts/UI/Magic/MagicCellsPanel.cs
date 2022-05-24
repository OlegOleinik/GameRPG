using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MagicCellsPanel : MonoBehaviour
{
    private MagicCell[] magicCells;
    public MagicCell selectedCell = null;
    private GameObject activeSpell;
    private Player player;
    private AttackController attackController;
    [SerializeField] MagicUpPanel magicUpPanel;
    //
    //
    //
    //DELITE AFTER TESTS
    [SerializeField] MagicScriptableObject[] spells;
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
        attackController = GameManager.player.GetComponent<AttackController>();
        magicCells = gameObject.GetComponentsInChildren<MagicCell>();
        for (int i = 0; i < magicCells.Length; i++)
        {
            magicCells[i].ClearCell();
            magicCells[i].id = i;
        }
        ChangeSelected(magicCells[0]);
        for (int i = 0; i < spells.Length; i++)
        {
            magicCells[i].DrawCell(spells[i]);
        }
        ShowSpellName();
    }

    private void Update()
    {

    }

    public int GetSpellLvl(MagicScriptableObject spell)
    {
        return magicUpPanel.GetSpellLvl(spell);
    }
    public float CastSpell()
    {
        if (activeSpell != null)
        {
            float magicCost = selectedCell.magic.magicCost + (selectedCell.magic.magicCost * GetSpellLvl(selectedCell.magic) * 0.1f);
            if (player.currentMagic >= magicCost && activeSpell.GetComponent<ASpell>().Spell())
            {
                player.WasteMagic(magicCost);
                return selectedCell.magic.coolDownTime;
            }
        }
        return -1;
    }


    public void SetByScroll(InputAction.CallbackContext inputValue)
    {
        float axis = inputValue.ReadValue<float>();
        if (axis != 0 && selectedCell != null)
        {
            
            if (selectedCell.id == 0 && axis < 0)
            {
                ChangeSelected(magicCells[magicCells.Length - 1]);
                return;
            }
            else if (selectedCell.id == magicCells.Length - 1 && axis > 0)
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
        int index = (int)inputValue.ReadValue<float>();
        if (index > magicCells.Length)
        {
            return;
        }
        if(inputValue.phase == InputActionPhase.Started)
        {
            ChangeSelected(magicCells[index]);
        }
    }

    public void SetSpellActivity(bool isActive)
    {
        if (isActive)
        {
            SetReadySpell();
            return;
        }
        SetNotReadySpell();
    }

    private void SetReadySpell()
    {
        if (selectedCell.magic != null)
        {
            activeSpell = Instantiate(selectedCell.magic.spell.gameObject, GameManager.player.transform);
            activeSpell.GetComponent<ASpell>().SetLvl(GetSpellLvl(selectedCell.magic));
        }
    }

    private void OnDisable()
    {
        SetNotReadySpell();
    }

    private void SetNotReadySpell()
    {
        if (activeSpell != null)
        {
            Destroy(activeSpell);
        }
    }

    public void ChangeSelected(MagicCell newCell)
    {
        if (selectedCell != null)
        {
            ClearSelected();
            SetNotReadySpell();
        }
        GameManager.ClickPlay();
        selectedCell = newCell;
        selectedCell.selected = true;
        selectedCell.SetEnterColor();
        if (attackController.isWeaponInHand)
        {
            SetReadySpell();
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

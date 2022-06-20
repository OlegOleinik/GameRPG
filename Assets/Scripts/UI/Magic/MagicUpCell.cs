using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicUpCell : AMagicCell, ISetInteractible
{
    [SerializeField] private Text costText;
    [SerializeField] private Text lvlText;
    [SerializeField] private Color unavailableColor = new Color(0.78f, 0.78f, 0.78f, 0.5f);
    private bool Interactible { get; set; } = true;

    private const int LVLCOST = 70;

    public void DrawCell(MagicScriptableObject spell, int lvl)
    {
        this.magic = spell;
        Image.sprite = spell.spellSprite;
        Image.color = new Color(1, 1, 1, 1);
        lvlText.text = System.Convert.ToString(lvl);
        if (lvl == 5)
        {
            costText.text = "Max";
            SetInteractible(false);
        }
        else
        {
            int upCost = lvl * LVLCOST;
            costText.text = System.Convert.ToString(upCost);
            SetInteractible(GameManager.player.GetComponent<Player>().money > upCost);
        }
    }
    public override void ClearCell()
    {
        magic = null;
        Image.sprite = null;
        Image.color = new Color(1, 1, 1, 0);
        lvlText.text = "";
        costText.text = "";
    }



    public override void OnMouseEnter()
    {
        if (Interactible)
        {
            SetEnterColor();
        }
    }

    public override void OnMouseExit()
    {
        if (Interactible)
        {
            SetDefaultColor();
        }
    }

    public void OnMouseClick()
    {
        if (Interactible)
        {
            gameObject.GetComponentInParent<MagicUpPanel>().UpSpellLvl(magic);
        }
    }

    public void SetInteractible(bool isInteractible)
    {
        Interactible = isInteractible;
        if (isInteractible)
        {
            SetDefaultColor();
        }
        else
        {
            gameObject.GetComponent<Image>().color = GameManager.cellColorDefault * unavailableColor;
        }
    }
}

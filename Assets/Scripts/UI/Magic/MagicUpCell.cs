using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicUpCell : AMagicCell
{
    [SerializeField] private Text costText;
    [SerializeField] private Text lvlText;

    public void DrawCell(MagicScriptableObject spell, int lvl)
    {
        this.magic = spell;
        Image.sprite = spell.spellSprite;
        Image.color = new Color(1, 1, 1, 1);
        lvlText.text = System.Convert.ToString(lvl);
        if (lvl == 5)
        {
            costText.text = "Max";
        }
        else
        {
            costText.text = System.Convert.ToString(lvl * 70);
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
        SetEnterColor();
    }

    public override void OnMouseExit()
    {
        SetDefaultColor();
    }

    public void OnMouseClick()
    {
        gameObject.GetComponentInParent<MagicUpPanel>().UpSpellLvl(magic);
    }
}

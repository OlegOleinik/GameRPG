using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicCell : MonoBehaviour
{
    public bool selected = false;
    private int _id;
    public MagicScriptableObject spell;
    [SerializeField]private Image Image;

    public int id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public void DrawCell(MagicScriptableObject spell)
    {
        this.spell = spell;
        Image.sprite = spell.spellSprite;
        Image.color = new Color(1, 1, 1, 1);
    }
    //Очистка клетки, а также очистка сохранения предмета и id. СТОИТ РАЗБИТЬ НА 2 МЕТОДА
    public void ClearCell()
    {
        spell = null;
        Image.sprite = null;
        Image.color = new Color(1, 1, 1, 0);
    }
    public void OnMouseEnter()
    {
        if (!selected)
        {
            gameObject.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
        }

    }
    public void OnMouseExit()
    {
        if (!selected)
        {
            gameObject.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
        }
    }
    public void OnMouseClick()
    {

        gameObject.GetComponentInParent<MagicCellsPanel>().ChangeSelected(this);

    }
}

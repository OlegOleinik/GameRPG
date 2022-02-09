using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellScript : MonoBehaviour
{
    public ItemScriptableObject item;
    public int id=-1;
    public Image Image;
    public Text text;
    public bool selected = false;

    //Отрисовка клетки, а также сохранение предмета и id ячейки. СТОИТ РАЗБИТЬ НА 2 МЕТОДА
    public void DrawCell(ItemScriptableObject item, int count, int id)
    {
        this.item = item;
        this.id = id;
        Image.sprite = item.itemSprite;
        Image.color = new Color(1, 1, 1, 1);
        text.text = count.ToString();
    }
    //Очистка клетки, а также очистка сохранения предмета и id. СТОИТ РАЗБИТЬ НА 2 МЕТОДА
    public void ClearCell()
    {
        this.item = null;
        this.id = -1;
        Image.sprite = null;
        Image.color = new Color(1, 1, 1, 0);
        text.text = "";
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
        if(item!=null)
        {
            gameObject.GetComponentInParent<InventoryPanel>().ChangeSelected(this);
        }

    }
}

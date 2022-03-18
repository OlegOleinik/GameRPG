using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCell : InventoryCellScript
{
    public override void OnMouseClick()
    {
        if (item != null)
        {
           gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInParent<ShopController>().ChangeSelected(this);
        }
    }
}

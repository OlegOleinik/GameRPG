using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCell : InventoryCellScript
{
    public override void OnMouseClick()
    {
         gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInParent<ShopController>().ChangeSelected(this);
    }
}

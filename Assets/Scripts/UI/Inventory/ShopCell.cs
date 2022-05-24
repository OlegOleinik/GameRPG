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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}

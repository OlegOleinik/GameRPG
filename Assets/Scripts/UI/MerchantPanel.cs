using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantPanel : MonoBehaviour
{
    [SerializeField] private ShopController shopController;
    private void OnDisable()
    {
        shopController.ClearSelected();
    }
}

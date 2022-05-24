using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantPotions : Merchant
{
    [SerializeField] private SpriteRenderer hair;
    [SerializeField] private SpriteRenderer face;
    [SerializeField] private SpriteRenderer hat;
    private Color hairColor;

    public override void Start()
    {
        base.Start();
        hairColor = hair.color;
    }
    protected override void InteracrionColorChange()
    {
        base.InteracrionColorChange();
        face.color = interactionColor;
        hair.color = interactionColor;
        hat.color = interactionColor;
    }

    protected override void StopInteracrionColorChange()
    {
        base.StopInteracrionColorChange();
        face.color = Color.white;
        hair.color = hairColor;
        hat.color = Color.white;
    }
}

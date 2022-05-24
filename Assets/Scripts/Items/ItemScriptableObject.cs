using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemScriptableObject : ScriptableObject
{
    public string type;
    public Sprite itemSprite;
    public string description;
    public int cost;
    public string itemName;
    public int maxItems;

    private void Awake()
    {
        type = "Useless";
    }
}





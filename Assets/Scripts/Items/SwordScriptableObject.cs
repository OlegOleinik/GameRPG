using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SwordScriptableObject : ItemScriptableObject
{
    public int damage;

    private void Awake()
    {
        type = "Sword";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class MagicScriptableObject : ScriptableObject
{
    public Sprite spellSprite;
    [TextArea] public string description;
    public float magicCost;
    public string spellName;
    public float coolDownTime;
    public ASpell spell;
}

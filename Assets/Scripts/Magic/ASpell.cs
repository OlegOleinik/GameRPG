using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpell : MonoBehaviour
{
    public abstract bool Spell();
    public virtual void Start()
    {
        
    }
    public abstract void SetLvl(int lvl);
}

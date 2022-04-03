using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpell : MonoBehaviour
{
    public abstract void Spell();
    public abstract void Start();

    public abstract void SetLvl(int lvl);

    //public abstract void SetLvl(int lvl);
}

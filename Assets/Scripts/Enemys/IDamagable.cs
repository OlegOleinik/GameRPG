using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void GetDamage(float damage, Vector2 force);
    void GetDamage(float damage);
    void LostHP(float damage);
    void GetForce(Vector2 force);
}

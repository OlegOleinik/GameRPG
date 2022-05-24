using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void GetDamage(float damage, Vector2 force);
<<<<<<< Updated upstream

    void GetDamage(float damage);

=======
    void GetDamage(float damage);
>>>>>>> Stashed changes
    void LostHP(float damage);
    void GetForce(Vector2 force);
}

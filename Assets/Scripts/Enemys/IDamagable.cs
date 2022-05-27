using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void GetDamage(float damage, Vector2 force);
<<<<<<< Updated upstream
<<<<<<< HEAD
    void GetDamage(float damage);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    void GetDamage(float damage);

=======
    void GetDamage(float damage);
>>>>>>> Stashed changes
=======
    void GetDamage(float damage);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
    void GetDamage(float damage);
>>>>>>> Stashed changes
    void LostHP(float damage);
    void GetForce(Vector2 force);
}

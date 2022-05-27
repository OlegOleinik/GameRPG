using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : ABar
{
    private AEnemy enemy;
    public override void Update()
    {
        if (enemy.currentHP < enemy.maxHP)
        {
            meshRenderer.enabled = true;
            UpdateParams();
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
<<<<<<< HEAD

=======
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public override void SetLocalParams()
    {
        enemy = GetComponentInParent<AEnemy>();
        GetComponent<MeshRenderer>().sortingOrder = 20;
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
=======
    public override void SetLocalParams()
    {
        enemy = GetComponentInParent<AEnemy>();
        GetComponent<MeshRenderer>().sortingOrder = 20;
    }

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
    public override void SetLocalParams()
    {
        enemy = GetComponentInParent<AEnemy>();
        GetComponent<MeshRenderer>().sortingOrder = 20;
    }

<<<<<<< Updated upstream
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
    public override void SetLocalParams()
    {
        enemy = GetComponentInParent<AEnemy>();
        GetComponent<MeshRenderer>().sortingOrder = 20;
    }

>>>>>>> Stashed changes
    public override float UpdateCount()
    {
        return enemy.currentHP / (float)enemy.maxHP;
    }

}

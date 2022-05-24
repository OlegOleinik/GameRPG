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

    public override void SetLocalParams()
    {
        enemy = GetComponentInParent<AEnemy>();
        GetComponent<MeshRenderer>().sortingOrder = 20;
    }

    public override float UpdateCount()
    {
        return enemy.currentHP / (float)enemy.maxHP;
    }

}

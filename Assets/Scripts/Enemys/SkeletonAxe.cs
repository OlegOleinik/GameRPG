using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAxe : MonoBehaviour
{
    private float attack;
    private float repulsion;
    private void Start()
    {
        attack = GetComponentInParent<Skeleton>().getAttack;
        repulsion = GetComponentInParent<Skeleton>().getRepulsion;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.tag != "Enemy")
        {
            IDamagable damagable = collisionObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.GetDamage(attack, (collisionObject.transform.position - transform.position).normalized * repulsion * 100);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private Collider2D viewCollider;
    private AEnemy ovner;

    public void SetCircleRadius(float radius, AEnemy ovner)
    {
        (viewCollider as CircleCollider2D).radius = radius;
        this.ovner = ovner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ovner.AddTarget(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ovner.RemoveTarget(collision.gameObject);
    }
}

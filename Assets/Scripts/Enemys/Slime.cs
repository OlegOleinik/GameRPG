using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : AEnemy
{
   // [SerializeField] private Rigidbody2D rb;
    [SerializeField] float maxJumpDistance = 1.5f;
    private float nextJumpCoolDown;

    public override void DieEvent()
    {
        
    }
    public override void SetStart()
    {
        nextJumpCoolDown = Time.time + 3f;
    }

    //public override void Move()
    //{
    //    //if (nextJumpCoolDown < Time.time)
    //    //{
    //    //    MoveToPos(new Vector2(3.5f, 8));
    //    //}

    //}

    public override void MoveToPos(Vector2 position)
    {
        if (nextJumpCoolDown < Time.time)
        {
            nextJumpCoolDown = Time.time + 2;
            rb.gravityScale = 2f;
            rb.drag = 1;

            Vector2 newPos = (position - (Vector2)transform.position).normalized;
            rb.AddForce( new Vector2(newPos.x, newPos.y + 1) * 5, ForceMode2D.Impulse);
            StartCoroutine(SetGravityNotActive());
        }
    }

    IEnumerator SetGravityNotActive()
    {
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = 0f;
        rb.drag = 30;
    }
    public override void DefaultWalk()
    {
        if (nextJumpCoolDown < Time.time)
        {
            MoveToPos(SetRandomTargetPoint());

        }
    }
}

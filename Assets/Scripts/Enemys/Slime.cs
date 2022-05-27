using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : AEnemy
{
    private float nextJumpCoolDown = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer bottomRenderer;
    [SerializeField] private Collider2D bottomCollider;
    private int orderSave = 10;
    private Vector3 baseScale;
    private IEnumerator jump;
    public override void DieEvent()
    {
        
    }

    public override void Start()
    {
        base.Start();
        baseScale = transform.localScale;
    }

  

    public override void Move()
    {
        if (nextJumpCoolDown < Time.time)
        {

            if ((Vector2.Distance(spawnPosition, transform.position) > 10))
            {
                _currentHP = maxHP;
                targetPoint = spawnPosition;
                SetSize(_currentHP / maxHP);
            }
            else if (isSeen && IsSeen(targetList[0]))
            {
                targetPoint = targetList[0].position;
            }
            else
            {
                DefaultWalk();
            }
            MoveToPos(targetPoint);
        }
    }

    protected override void DefaultWalk()
    {
        targetPoint = SetRandomTargetPoint();
    }



    protected override void MoveToPos(Vector2 position)
    {
        nextJumpCoolDown = Time.time + 10;
        jump = Jump();
        StartCoroutine(jump);
    }


    private IEnumerator Jump()
    {
        audioSource.Play();
        bottomCollider.enabled = false;
        orderSave = bottomRenderer.sortingOrder;
        bottomRenderer.sortingOrder = 10;

        animator.SetBool("isJump", true);
        Vector3 axis = (targetPoint - (Vector2)transform.position);
        if (Vector2.Distance(transform.position, targetPoint) > 2)
        {
            axis = axis.normalized;
        }
        else
        {
            axis /= 2;
        }
        Vector3 point = transform.position + (axis);
        Vector3 v = transform.position - point;
        float rotateDeg = 0;
        while (rotateDeg < 180)
        {
            v = Quaternion.AngleAxis(Time.deltaTime * -200, new Vector3(axis.y, 0, axis.x)) * v;
            rotateDeg += Time.deltaTime * 200;
            transform.position = point + v;
            yield return null;
        }
        EndJump();
    }


    public override void GetDamage(float damage, Vector2 force)
    {
        base.GetDamage(damage, force);
        DamageParticles();
        SetSize(_currentHP / maxHP);
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        DamageParticles();
        SetSize(_currentHP / maxHP);
    }

    private void EndJump()
    {
        audioSource.Play();
        bottomRenderer.sortingOrder = orderSave;
        bottomCollider.enabled = true;
        animator.SetBool("isJump", false);
        nextJumpCoolDown = Time.time + 1 + Random.Range(-0.3f, 0.3f);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        StopCoroutine(jump);
        EndJump();
        audioSource.Play();
    }


    private void SetSize(float mod)
    {
        Vector3 half = Vector3.one * 0.5f;
        Vector3 newScale = ((baseScale - half) * mod + half);
        transform.localScale = new Vector3 (newScale.x, newScale.y, 1);
    }
}

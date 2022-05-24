using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : AEnemy
{
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
   // [SerializeField] private Rigidbody2D rb;
    [SerializeField] float maxJumpDistance = 1.5f;
    private float nextJumpCoolDown;

=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    private float nextJumpCoolDown = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer bottomRenderer;
    [SerializeField] private Collider2D bottomCollider;
    private int orderSave = 10;
    private Vector3 baseScale;
    private IEnumerator jump;
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public override void DieEvent()
    {
        
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76

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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
}

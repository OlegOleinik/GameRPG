using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Skeleton : AEnemy
{
    [SerializeField] private AIPath aIPath;
    [SerializeField] private GameObject targerForPathfinder;
    [SerializeField] private Animator mainAnimator;
    [SerializeField] private Rigidbody rb3D;
    [SerializeField] private AudioClip getDamage;
    [SerializeField] private AudioClip axeSlash;

    public override void Start()
    {
        base.Start();
        aIPath.maxSpeed = speed;
    }

    public override void Move()
    {
        SetFlip(aIPath.desiredVelocity.x);
        if ((Vector2.Distance(spawnPosition, transform.position) > 15))
        {
            _currentHP = maxHP;
            targetPoint = spawnPosition;
            MoveToPos(targetPoint);
            return;
        }
        else if (isSeen && (Vector2.Distance(spawnPosition, transform.position) < 10))
        {
            if(transform.position.y - targetList[0].transform.position.y < 0.1)
            {
                targetPoint = targetList[0].position;
            }
            else
            {
                targetPoint = targetList[0].position - Vector3.left * 2 * targetList[0].localScale.x;

            }
            MoveToPos(targetPoint);
            vaitTime = Time.time + 5;
            return;
        }
        else
        {
            DefaultWalk();
        }
    }

    protected override void DefaultWalk()
    {
        if (vaitTime < Time.time)
        {
            targetPoint = SetRandomTargetPoint();
            vaitTime = Time.time + 5;
        }
        MoveToPos(targetPoint);
    }

    protected override void OnCollisionStay2D(Collision2D collision)
    {

    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if ((collisionObject.tag != "Enemy") && (collisionObject.tag != "Wall") && (transform.position.y - collisionObject.transform.position.y < 0.2) && (collisionObject.GetComponent<IDamagable>() != null))
        {
            AttackAnimation();
        }
    }


    protected override void MoveToPos(Vector2 position)
    {
        targerForPathfinder.transform.position = new Vector3(position.x, position.y, 0);
        if ((Vector2.Distance(targetPoint, transform.position) > 0.2))
        {
            AnimationWalk();
        }
        else
        {
            AnimationIdle();
        }
    }
    public override void DieEvent()
    {
        GameManager.player.GetComponent<QuestsController>().onSkeletonKilled?.Invoke();
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        audioSource.PlayOneShot(getDamage);
    }

    public override void GetDamage(float damage, Vector2 force)
    {
        base.GetDamage(damage, force);
        audioSource.PlayOneShot(getDamage);
    }

    public override void GetForce(Vector2 force)
    { 
        StartCoroutine(SetPosWhileForce(force));
    }

    //AStart поиск пути ломает физику 2D, этот костыль исправляет
    private IEnumerator SetPosWhileForce(Vector2 force)
    {
        rb3D.isKinematic = false;
        rb3D.AddForce(force * transform.localScale.x, ForceMode.Impulse);
        float startScale = transform.localScale.x;
        GameObject rbObject = rb3D.gameObject;
        float timer = Time.time + 1.5f;
        while (timer > Time.time)
        {
            transform.position += rbObject.transform.localPosition * startScale * transform.localScale.x;
            rbObject.transform.localPosition = Vector3.zero;
            yield return null;
        }
        rb3D.isKinematic = true;
        rbObject.transform.localPosition = Vector3.zero;
    }

    private void AnimationIdle()
    {
        mainAnimator.SetBool("Walk", false);
        if (audioSource.isPlaying == true)
        {
            audioSource.loop = false;
        }
    }

    protected override void AttackAnimation()
    {
        mainAnimator.SetTrigger("Attack");
        audioSource.PlayOneShot(axeSlash);
    }
    
    private void AnimationWalk()
    {
        mainAnimator.SetBool("Walk", true);
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
            audioSource.loop = true;
        }
    }
    private void AnimationDeath()
    {
        mainAnimator.SetTrigger("Death");
        audioSource.Stop();
    }

    private void SetFlipOnAttack()
    {
        SetFlip(targetList[0].position.x - transform.position.x);
    }

    private void StopGo()
    {
        aIPath.maxSpeed = 0;
    }

    private void ResumeGo()
    {
        aIPath.maxSpeed = speed;
    }

    public override void WaterCollisionEnter()
    {
        base.WaterCollisionEnter();
        aIPath.maxSpeed = speed;
    }
    public override void WaterCollisionExit()
    {
        base.WaterCollisionExit();
        aIPath.maxSpeed = speed;
    }

    public override void Die()
    {
        AnimationDeath();
    }

}

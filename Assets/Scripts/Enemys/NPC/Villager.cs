using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : ANPC
{
    private State normal;
    private State playerAttack;
    [SerializeField] private SpriteRenderer hair;
    [SerializeField] private SpriteRenderer face;
    private Color hairColor;

    public override void Start()
    {
        base.Start();
        normal = new State(NormalState);
        playerAttack = new State(PlayerAttackState);
        currentState = normal;
        targetPoint = spawnPosition;
        hairColor = hair.color;
    }

    private void NormalState()
    {
        if (vaitTime < Time.time)
        {
            targetPoint = SetRandomTargetPoint();
            vaitTime = Time.time + 5;
        }
        if (Vector2.Distance(transform.position, targetPoint) > 0.2)
        {
            AnimationWalk();
            SetFlip(aIPath.desiredVelocity.x);
            MoveToPos(targetPoint);
        }
        else
        {
            AnimationIdle();
        }
    }

    private void PlayerAttackState()
    {
        if (Vector2.Distance(transform.position, targerForPathfinder.transform.position) < 1)
        {
            targetPoint = SetRandomTargetPoint();
        }
        SetFlip(aIPath.desiredVelocity.x);
        MoveToPos(targetPoint);
    }

    protected override void InteracrionColorChange()
    {
        base.InteracrionColorChange();
        face.color = interactionColor;
        hair.color = interactionColor;
    }
    protected override void StopInteracrionColorChange()
    {
        base.StopInteracrionColorChange();
        face.color = Color.white;
        hair.color = hairColor;
    }

    private void AnimationIdle()
    {
        bodyAnimator.SetBool("isWalk", false);
        enemyLegAnimator.SetBool("isWalk", false);
        IdleAudio();
    }

    private void AnimationWalk()
    {
        bodyAnimator.SetBool("isWalk", true);
        enemyLegAnimator.SetBool("isWalk", true);
        WalkAudio();

    }

    private void AnimationRun()
    {
        bodyAnimator.speed = 1.5f;
        enemyLegAnimator.speed = 1.5f;
        AnimationWalk();
        RunAudio();
    }

    public override void SetAngryToPlayer()
    {
        if (!isAngryToPlayer)
        {
            base.SetAngryToPlayer();
            currentState = playerAttack;
            AnimationRun();
            aIPath.maxSpeed *= 2;
        }
    }

    public override void DieEvent()
    {

    }
}

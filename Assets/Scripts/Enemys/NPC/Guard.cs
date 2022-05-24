using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guard : ANPC
{
    private State patrol;
    private State fight;
    [SerializeField] private SpriteRenderer sheath;
    [SerializeField] private SpriteRenderer sword;
    [SerializeField] SwordScriptableObject[] swordsOptions;
    [SerializeField] private AudioClip unsheatSound;
    [SerializeField] private AudioClip sheathSound;
    [SerializeField] private AudioClip slashSound;
    private float atcCooldown = 0;
    private System.Action moveAnimation;

    public override void Start()
    {
        base.Start();
        patrol = new State(Patrol);
        fight = new State(Fight);
        currentState = patrol;
        SwordScriptableObject newSword = swordsOptions[Random.Range(0, swordsOptions.Length)];
        sheath.sprite = newSword.itemSprite;
        sword.sprite = newSword.itemSprite;
        attack = newSword.damage;
        moveAnimation = AnimationWalk;
        if(DropList == null)
        {
            DropList = new List<ItemScriptableObject>();
            DropChanceList = new List<float>();
        }
        DropList.Add(newSword);
        DropChanceList.Add(1);
    }

    protected override void StartTalk()
    {
        if (isSeen)
        {
            Talk(battlePhrases[Random.Range(0, battlePhrases.Length)]);
        }
        else if (GameManager.player.GetComponent<AttackController>().isWeaponInHand)
        {
            Talk(usualNervousnessPhrases[Random.Range(0, usualNervousnessPhrases.Length)]);
        }
        else
        {
            Talk(usualPhrases[Random.Range(0, usualPhrases.Length)]);
        }
    }

    public override void SetAngryToPlayer()
    {
        if (!isAngryToPlayer )
        {
            base.SetAngryToPlayer();
            if((Vector2.Distance(transform.position, GameManager.player.transform.position) < seenDistance))
            {
                AddTarget(GameManager.player);
            }
        }
    }

    private void Patrol()
    {
        SetFlip(aIPath.desiredVelocity.x);
        DefaultWalk();
    }

    private void Fight()
    {
        SetFlip(aIPath.desiredVelocity.x);
        if (targetList[0] == null)
        {
            targetList.RemoveAt(0);
            if (targetList.Count < 1)
            {
                isSeen = false;
                HideSword();
                currentState = patrol;
                aIPath.maxSpeed /= 2f;
                moveAnimation = AnimationWalk;
                audioSource.PlayOneShot(sheathSound);
                return;
            }
        }
        if ((transform.position.y - targetList[0].transform.position.y < 0.1))
        {
            targetPoint = targetList[0].position;
        }
        else
        {
            targetPoint = targetList[0].position - Vector3.left * 2 * targetList[0].localScale.x;

        }
        MoveToPos(targetPoint);
        return;
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

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    protected override void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            targetPoint = SetRandomTargetPoint();
            return;
        }
        if ((collision.gameObject.tag != "Wall") && ((isAngryToPlayer && collision.gameObject.tag == "Player") || (collision.gameObject.tag == "Enemy"))
            && (transform.position.y - collision.gameObject.transform.position.y < 0.2)  && atcCooldown < Time.time && (collision.gameObject.GetComponent<IDamagable>() != null)/*(gameObject.tag != collision.gameObject.tag) && (targetList.Count > 0)*/)
        {
            if (Random.Range(0, 2) == 0)
            {
                AttackHitAnimation();
            }
            else
            {
                AttackSlashAnimation();
            }
            atcCooldown = Time.time + 0.5f;
            audioSource.PlayOneShot(slashSound);
            SetFlip(targetList[0].position.x - transform.position.x);
        }
    }

    protected override void SetFlip(float x)
    {
        base.SetFlip(x);
        if (transform.localScale.x == -1)
        {
            sheath.sortingOrder = 5;
        }
        else
        {
            sheath.sortingOrder = 4;
        }
    }

    public override void AddTarget(GameObject newTarget)
    {

        if ( (isAngryToPlayer && newTarget.tag == "Player") || newTarget.tag == "Enemy")
        {
            targetList.Add(newTarget.transform);
            if (!isSeen)
            {
                GetSword();
                currentState = fight;
                isSeen = true;
                aIPath.maxSpeed *= 2f;
                moveAnimation = AnimationRun;
                audioSource.PlayOneShot(unsheatSound);
            }
        }
    }

    public override void RemoveTarget(GameObject lostTarget)
    {
        if ((isAngryToPlayer && lostTarget.tag == "Player") || lostTarget.tag == "Enemy")
        {
            targetList.Remove(lostTarget.transform);
            if (targetList.Count < 1)
            {
                isSeen = false;
                HideSword();
                currentState = patrol;
                aIPath.maxSpeed /= 2f;
                moveAnimation = AnimationWalk;
                audioSource.PlayOneShot(sheathSound);
            }
        }
    }

    protected override void MoveToPos(Vector2 position)
    {
        base.MoveToPos(position);
        if ((Vector2.Distance(targetPoint, transform.position) > 0.2))
        {
            moveAnimation();
        }
        else
        {
            AnimationIdle();
        }
    }

    public override void Die()
    {
        AnimationDeath();
    }

    public override void DieEvent()
    {
       
    }

    private void GetSword()
    {
        bodyAnimator.SetBool("IsBattle", true);
    }

    private void HideSword()
    {
        bodyAnimator.SetBool("IsBattle", false);
    }
    private void AnimationIdle()
    {
        bodyAnimator.SetInteger("moveState", 0);
        enemyLegAnimator.SetInteger("moveState", 0);
        IdleAudio();
    }

    private void AttackSlashAnimation()
    {
        bodyAnimator.SetTrigger("Slash");
    }

    private void AttackHitAnimation()
    {
        bodyAnimator.SetTrigger("Hit");
    }

    private void AnimationWalk()
    {
        bodyAnimator.SetInteger("moveState", 1);
        enemyLegAnimator.SetInteger("moveState", 1);
        WalkAudio();
    }

    private void AnimationRun()
    {
        bodyAnimator.SetInteger("moveState", 2);
        enemyLegAnimator.SetInteger("moveState", 2);
        RunAudio();
    }

    private void AnimationDeath()
    {
        bodyAnimator.SetTrigger("Death");
        enemyLegAnimator.SetTrigger("Death");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
public class Rooster : Enemy_1
{

=======
=======
>>>>>>> Stashed changes
public class Rooster : AEnemy
{
    [SerializeField] private Animator roosterBodyAnimator;
    public override void AttackAnimation()
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
public class Rooster : AEnemy
{
    [SerializeField] private Animator roosterBodyAnimator;
    [SerializeField] private AudioClip roosterDefault;
    [SerializeField] private AudioClip roosterAtc;
    private float nextKokoko = 0;

    protected override void AttackAnimation()
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    {
        roosterBodyAnimator.SetBool("isAttack", true);
        StartCoroutine(SetNotAttack());
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!audioSource.isPlaying && nextKokoko < Time.time)
        {
            audioSource.clip = roosterDefault;
            audioSource.Play();
            nextKokoko = Time.time + Random.Range(2, 6);
        }
    }


    public override void GetDamage(float damage, Vector2 force)
    {
        base.GetDamage(damage, force);
        DamageParticles();
        PlayAtcSound();
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        DamageParticles();
        PlayAtcSound();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            PlayAtcSound();
        }
    }

    private void PlayAtcSound()
    {
        audioSource.clip = roosterAtc;
        audioSource.Play();
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    IEnumerator SetNotAttack()
    {
        yield return new WaitForSeconds(0.1f);
        roosterBodyAnimator.SetBool("isAttack", false);
<<<<<<< HEAD
    }

=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    }
=======
    }

>>>>>>> Stashed changes
=======
    }

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public override void DieEvent()
    {
        GameManager.player.GetComponent<QuestsController>().onRoosterKilled?.Invoke();
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76

    protected override void MoveToPos(Vector2 position)
    {
        base.MoveToPos(position);
        enemyLegAnimator.SetInteger("State", 1);
    }

    protected override void DefaultWalk()
    {
        if (rb.position != targetPoint)
        {
            MoveToPos(targetPoint);
        }
        else
        {
            enemyLegAnimator.SetInteger("State", 0);
            if (vaitTime == -1)
            {
                vaitTime = Time.time + 1;
            }
            else if (vaitTime < Time.time)
            {
                targetPoint = SetRandomTargetPoint();
                vaitTime = -1;
            }
        }
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}

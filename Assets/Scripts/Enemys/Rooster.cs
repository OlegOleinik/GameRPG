using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    {
        roosterBodyAnimator.SetBool("isAttack", true);
        StartCoroutine(SetNotAttack());
    }

    IEnumerator SetNotAttack()
    {
        yield return new WaitForSeconds(0.1f);
        roosterBodyAnimator.SetBool("isAttack", false);

    }
    public override void DieEvent()
    {
        GameManager.player.GetComponent<QuestsController>().onRoosterKilled?.Invoke();
    }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class OnSaleItem
{
    public OnSaleItem(ItemScriptableObject item)
    {
        this.item = item;
        count = 1;
    }
    public ItemScriptableObject item;
    public int count;
}

public class Merchant : ANPC
{
    private ShopController shopController;
    public List<OnSaleItem> onSaleItems;
    private State normal;
    private State playerAttack;
    [SerializeField] Sprite portrait;

    public override void Start()
    {
        base.Start();
        shopController = GameManager.UI.GetComponent<UIScript>().shopController;
        normal = new State(NormalState);
        playerAttack = new State(PlayerAttackState);
        currentState = normal;
        //Проверка на ограничение кол-ва вещей в ячейке
        foreach (var item in onSaleItems)
        {
            if(item.item.maxItems<item.count)
            {
                item.count = item.item.maxItems;
            }
        }
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

    private void NormalState()
    {
        targetPoint = spawnPosition;
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

    protected override void StartTalk()
    {
        if (isAngryToPlayer)
        {
            Talk((battlePhrases[Random.Range(0, usualPhrases.Length)]));
            return;
        }
        else if (GameManager.player.GetComponent<AttackController>().isWeaponInHand)
        {
            Talk(usualNervousnessPhrases[Random.Range(0, usualNervousnessPhrases.Length)]);
            return;
        }
        GameManager.player.GetComponent<InteractionController>().ClearInteraction();
        GameManager.player.GetComponent<NPCController>().StartDialogue(nPCid, portrait);
    }

    protected override void StopTalk()
    {
        GameManager.player.GetComponent<NPCController>().StopDialog();
    }

    public void OpenShop()
    {
        if (GameManager.UI.GetComponent<UIScript>().CheckNotOpen(shopController.gameObject))
        {
            shopController.gameObject.SetActive(true);
            shopController.OpenShop(this);
        }
    }

    public void AddItem(ItemScriptableObject addItem)
    {
        foreach (OnSaleItem slot in onSaleItems)
        {
            if (slot.item == addItem && slot.count < addItem.maxItems)
            {
                slot.count++;
                return;
            }
        }
        if (onSaleItems.Count >= 23)
        {
            return;
        }
        onSaleItems.Add(new OnSaleItem(addItem));
    }
    public bool RemoveItem(int id)
    {
        if(--onSaleItems[id].count<=0)
        {
            onSaleItems.RemoveAt(id);
            return true;
        }
        return false;
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

    public override void DieEvent()
    {

    }
}

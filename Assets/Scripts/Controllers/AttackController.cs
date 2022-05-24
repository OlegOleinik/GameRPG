using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class AttackController : MonoBehaviour
{
    public Sword sword;
    private MagicCellsPanel magicCellsPanel;
    private float swordCoolDownTime;
    private float magicCoolDownTime;
    private float nextRegFire1; //ƒанна€ переменна€ дл€ удобства ввода атаки

    private bool _isWeaponInHand = false;
    [SerializeField] private PlayerAnimator playerAnimator;

    void Start()
    {
        magicCellsPanel = GameManager.UI.GetComponentInChildren<MagicCellsPanel>();
    }

    public bool isWeaponInHand
    {
        get
        {
            return _isWeaponInHand;
        }
    }

    public void MagicAttack(InputAction.CallbackContext inputValue)
    {
        if (EnableToMagicAttck() && GameManager.isGamePaused == false)
        {
            SetMagicCoolDown(magicCellsPanel.CastSpell());
            playerAnimator.MagicCast();
            playerAnimator.FlipPlayer(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - transform.position.x);
            playerAnimator.BlockFlip(0.19f);
        }
    }

    public SwordScriptableObject GetSword()
    {
        return sword.sword;
    }

    public void SwordAttack(InputAction.CallbackContext inputValue)
    {
        if (EventSystem.current.IsPointerOverGameObject() || GameManager.isGamePaused)
        {
            return;
        }

        if (nextRegFire1 < Time.time && EnableToSwordAttck())
        {
            sword.gameObject.SetActive(true);
            sword.Strike1();
            nextRegFire1 = Time.time + 0.3f;
            StartCoroutine(CheckHoldLeftButton(inputValue.action));


        }
    }

    private IEnumerator CheckHoldLeftButton(InputAction inputValue)
    {
        while (sword.isActiveAndEnabled)
        {
            if (inputValue.IsPressed())
            {
                if (EventSystem.current.IsPointerOverGameObject() || sword.isNextStrike)
                {
                    yield return null;
                }
                if (nextRegFire1 < Time.time)
                {
                    sword.isNextStrike = true;
                    nextRegFire1 = Time.time + 0.2f;
                }
            }
            yield return null;
        }

    }


    public void SwitchWeaponReady(bool isReady)
    {
        if (swordCoolDownTime < Time.time)
        {
            sword.GetHideSword(!isReady);
            SetSwordCoolDown(0.7f * (0.1f / GameManager.player.GetComponent<Player>().attackCooldown));
            _isWeaponInHand = isReady;
            magicCellsPanel.SetSpellActivity(isReady);
        }
    }



    public void SwitchWeaponReady(InputAction.CallbackContext inputValue)
    {
        SwitchWeaponReady(!_isWeaponInHand);
    }




    //¬ данном случае провер€етс€ меч, чтобы не кастовать при ударе мечем
    public bool EnableToMagicAttck()
    {
        return (_isWeaponInHand && sword.ableToAttack && magicCoolDownTime < Time.time);
    }
    //¬озвращает TRUE, если возможна атака и прошло достаточно времени с предыдущей
    public bool EnableToSwordAttck()
    {
        return (_isWeaponInHand && sword.ableToAttack && swordCoolDownTime < Time.time);
    }

    public void SetSwordCoolDown(float addTime)
    {
        swordCoolDownTime = Time.time + addTime;
    }

    public void SetMagicCoolDown(float addTime)
    {
        magicCoolDownTime = Time.time + addTime;
    }
}

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

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private bool isWeaponInHand = false;
=======
    private bool _isWeaponInHand = false;
>>>>>>> Stashed changes
=======
    private bool _isWeaponInHand = false;
>>>>>>> Stashed changes
    [SerializeField] private PlayerAnimator playerAnimator;

    void Start()
    {
        magicCellsPanel = GameManager.UI.GetComponentInChildren<MagicCellsPanel>();
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
    public bool isWeaponInHand
    {
        get
        {
            return _isWeaponInHand;
        }
    }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    public void MagicAttack(InputAction.CallbackContext inputValue)
    {
        if (EnableToMagicAttck() && GameManager.isGamePaused == false)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            SetMagicCoolDown(MagicCellsPanel.CastSpell());
            playerAnimator.MagicCast();


=======
            SetMagicCoolDown(magicCellsPanel.CastSpell());
            playerAnimator.MagicCast();
>>>>>>> Stashed changes
=======
            SetMagicCoolDown(magicCellsPanel.CastSpell());
            playerAnimator.MagicCast();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            if (EnableToSwordAttck())
            {
                sword.gameObject.SetActive(true);
                sword.Strike1();

                nextRegFire1 = Time.time + 0.3f;
                StartCoroutine(CheckHoldLeftButton(inputValue.action));
            }
=======
=======
>>>>>>> Stashed changes
            return;
        }

        if (nextRegFire1 < Time.time && EnableToSwordAttck())
        {
            sword.gameObject.SetActive(true);
            sword.Strike1();
            nextRegFire1 = Time.time + 0.3f;
            StartCoroutine(CheckHoldLeftButton(inputValue.action));

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if(swordCoolDownTime < Time.time)
        {
            sword.GetHideSword(isWeaponInHand);
            SetSwordCoolDown(0.7f * (0.1f / GameManager.player.GetComponent<Player>().attackCooldown));
            isWeaponInHand = !isWeaponInHand;
        }

=======
        SwitchWeaponReady(!_isWeaponInHand);
>>>>>>> Stashed changes
=======
        SwitchWeaponReady(!_isWeaponInHand);
>>>>>>> Stashed changes
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

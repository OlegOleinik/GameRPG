using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sword sword;
    private MagicCellsPanel MagicCellsPanel;
    private float swordCoolDownTime;
    private float magicCoolDownTime;
    private float nextRegFire1; //ƒанна€ переменна€ дл€ удобства ввода атаки

    private bool isWeaponInHand = false;
    [SerializeField] private PlayerAnimator playerAnimator;

    void Start()
    {
        //sword.gameObject.SetActive(false);
        MagicCellsPanel = GameObject.Find("MagicCells").GetComponent<MagicCellsPanel>();
    }


    public void MagicAttack(InputAction.CallbackContext inputValue)
    {
        if (/*inputValue.phase == InputActionPhase.Started && */EnableToMagicAttck() && GameManager.isGamePaused == false)
        {
            SetMagicCoolDown(MagicCellsPanel.CastSpell());
            playerAnimator.MagicCast();


            playerAnimator.FlipPlayer(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - transform.position.x);
            playerAnimator.BlockFlip(0.19f);
        }
    }


    public void SwordAttack(InputAction.CallbackContext inputValue)
    {
        if (/*inputValue.phase == InputActionPhase.Started &&*/ GameManager.isGamePaused == false && nextRegFire1 < Time.time)
        {
            if (EnableToSwordAttck())
            {
                sword.gameObject.SetActive(true);
                sword.Strike1();

                nextRegFire1 = Time.time + 0.3f;
                StartCoroutine(CheckHoldLeftButton(inputValue.action));
            }

        }
    }

    private IEnumerator CheckHoldLeftButton(InputAction inputValue)
    {
        while (sword.isActiveAndEnabled)
        {
            if (inputValue.IsPressed() && !sword.isNextStrike && nextRegFire1 < Time.time)
            {
                sword.isNextStrike = true;
                nextRegFire1 = Time.time + 0.2f;
            }
            yield return null;
        }

    }

    public void SwitchWeaponReady(InputAction.CallbackContext inputValue)
    {
        if(swordCoolDownTime < Time.time)
        {
            sword.GetHideSword(isWeaponInHand);
            SetSwordCoolDown(0.7f * (0.1f / GameManager.player.GetComponent<Player>().attackCooldown));
            isWeaponInHand = !isWeaponInHand;
        }

    }




    //¬ данном случае провер€етс€ меч, чтобы не кастовать при ударе мечем
    public bool EnableToMagicAttck()
    {
        return (isWeaponInHand && sword.ableToAttack && magicCoolDownTime < Time.time);
    }
    //¬озвращает TRUE, если возможна атака и прошло достаточно времени с предыдущей
    public bool EnableToSwordAttck()
    {
        return (isWeaponInHand && sword.ableToAttack && swordCoolDownTime < Time.time);
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

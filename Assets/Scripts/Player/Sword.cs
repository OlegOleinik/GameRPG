using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    private bool _ableToAttack = true;
    [SerializeField] private SwordScriptableObject _sword;
    private SpriteRenderer swordSpriteRenderer;
    [SerializeField] private SpriteRenderer sheath;
    [SerializeField] private SpriteRenderer swordInHand;
    private Player player;
    private GameManager.EndCorutine end;
    private float strikeNumMod;
    private int strikeNum = 0;
    [SerializeField] private AudioClip unsheathSword;
    [SerializeField] private AudioClip sheathSword;
    [SerializeField] private AudioClip swordWall;
    [SerializeField] private AudioClip swordSlash;
    [SerializeField] private PlayerAnimator playerAnimator;
    private bool _isNextStrike = false;

    private const float ANGLEOFFSET = 60;
    private const float SWORDCDMOD = 0.7f;

    public bool isNextStrike
    {
        get
        {
            return _isNextStrike;
        }
        set
        {
            _isNextStrike = value;
        }
    }

    public bool ableToAttack
    {
        get
        {
            return _ableToAttack;
        }
    }


    public SwordScriptableObject sword
    {
        get
        {
            return _sword;
        }
    }
    private void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        swordSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        end = EndStrike;
        gameObject.SetActive(false);
        SetSword(_sword);
        GetHideSword(true);
    }
    public void GetHideSword(bool isActive)
    {
        sheath.gameObject.SetActive(isActive);
        swordInHand.gameObject.SetActive(!isActive);
        if (isActive)
        {
            SwordDisappear();
            playerAnimator.HideWeapon();
            player.PlaySound(sheathSword);
        }
        else
        {
            playerAnimator.ReadyWeapon();
            player.PlaySound(unsheathSword);

        }
    }

    public void SetSword(SwordScriptableObject newSword)
    {
        GameManager.player.GetComponent<PlayerAudio>().PlayItemUpSound();
        _sword = newSword;
        swordSpriteRenderer.sprite = _sword.itemSprite;
        sheath.sprite = _sword.itemSprite;
        swordInHand.sprite = _sword.itemSprite;
    }

    public ItemScriptableObject GetSword()
    {
        return _sword;
    }

    private void EndStrike()
    {
        //Возможно, переписать
        if (_isNextStrike && strikeNum < 3)
        {
            if (strikeNum == 1)
            {
                Strike2();
            }
            else if (strikeNum == 2)
            {
                Strike3();
            }
        }
        else
        {
            swordInHand.gameObject.SetActive(true);
            GetComponentInParent<AttackController>().SetSwordCoolDown(SWORDCDMOD * (0.1f / player.attackCooldown));
            SwordDisappear();
        }

    }
    //Пропажа меча и кулдаун атаки
    private void SwordDisappear()
    {
        transform.localPosition = new Vector3(0, -0.19f, 0);
        playerAnimator.ReadyWeapon();
        strikeNum = 0;
        isNextStrike = false;
        gameObject.SetActive(false);
        _ableToAttack = true;
    }

    private float GetX()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - transform.position.x;
    }

    private float GetAngle(float x)
    {
        return Mathf.Atan2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - transform.position.y, x) * Mathf.Rad2Deg;
    }

    //Удар 1
    public void Strike1()
    {
        swordInHand.gameObject.SetActive(false);
        playerAnimator.Strike1();
        player.PlaySound(swordSlash);
        strikeNum = 1;
        strikeNumMod = 1;
        float x = GetX();
        float angle = GetAngle(x);
        int flipMod = LeftRigntMod(x);
        _ableToAttack = false;
        playerAnimator.FlipPlayer(x);
        playerAnimator.BlockFlip(0.45f);
        if (playerAnimator.isFlip)
        {
            angle += 180;
        }
        StartCoroutine(0.5f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle + (flipMod * ANGLEOFFSET), angle - (flipMod * ANGLEOFFSET), end));
    }

    //Удар 2
    public void Strike2()
    {
        playerAnimator.Strike2();
        player.PlaySound(swordSlash);
        strikeNum = 2;
        isNextStrike = false;
        strikeNumMod = 0.6f;
        float x = GetX();
        float angle = GetAngle(x);
        int flipMod = LeftRigntMod(x);
        playerAnimator.FlipPlayer(x);
        playerAnimator.BlockFlip(0.45f);
        if (playerAnimator.isFlip)
        {
            angle += 180;
        }
        StartCoroutine(0.5f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle - (flipMod * ANGLEOFFSET), angle + (flipMod * ANGLEOFFSET), end));
    }
    public void Strike3()
    {
        playerAnimator.Strike3();
        player.PlaySound(swordSlash);
        strikeNum = 3;
        isNextStrike = false;
        strikeNumMod = 1.3f;
        float x = GetX();
        float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - transform.position.y;
        float angle = GetAngle(x);
        _ableToAttack = false;
        playerAnimator.FlipPlayer(x);
        playerAnimator.BlockFlip(0.19f);
        int flipMod = LeftRigntMod(x);
        if (playerAnimator.isFlip)
        {
            angle += 180;
        }
        StartCoroutine(0.2f.Tweeng((u) => transform.localPosition = u, new Vector3(0, 0, 0), new Vector3(x * flipMod, y , 0).normalized / 5, end));
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    //Столкновение меча с чем-либо. С врагом-отталкивет, со стеной-пропадает.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            swordInHand.gameObject.SetActive(true);
            player.PlaySound(swordWall);

            GetComponentInParent<AttackController>().SetSwordCoolDown(SWORDCDMOD * (0.1f / player.attackCooldown));
            SwordDisappear();
            return;
        }
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.GetDamage(strikeNumMod * _sword.damage * player.attack, player.repulsion * 100 * (collision.transform.position - transform.position).normalized);
            if(collision.tag == "NPC")
            {
                collision.GetComponent<ANPC>().GetAttackedByPlayer();
            }
        }
    }

    private int LeftRigntMod(float x)
    {
        if (x < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}

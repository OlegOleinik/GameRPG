using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _ableToAttack = true;
    [SerializeField] private SwordScriptableObject sword;
    private SpriteRenderer swordSpriteRenderer;
    [SerializeField] private SpriteRenderer sheath;
    [SerializeField] private SpriteRenderer swordInHand;
    private Player player;
    private GameManager.EndCorutine end;
    private float strikeNumMod;
    private int strikeNum = 0;


    [SerializeField] private PlayerAnimator playerAnimator;
    private bool _isNextStrike = false;

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
    private void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        swordSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        end = EndStrike;
        gameObject.SetActive(false);
        SetSword(sword);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        }
        else
        {
            playerAnimator.ReadyWeapon();
        }
=======
        }
        else
        {
            playerAnimator.ReadyWeapon();
        }
>>>>>>> Stashed changes

    }



    public void SetSword(SwordScriptableObject newSword)
    {
        sword = newSword;
        swordSpriteRenderer.sprite = sword.itemSprite;
        sheath.sprite = sword.itemSprite;
        swordInHand.sprite = sword.itemSprite;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        //GameManager.UI.GetComponentInChildren<Inventory>().DrawCell(sword);
    }

    public ItemScriptableObject GetSword()
    {
        return sword;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
            GetComponentInParent<AttackController>().SetSwordCoolDown(0.7f * (0.1f / player.attackCooldown));
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
        strikeNum = 1;
        strikeNumMod = 1;
        float x = GetX();
        float angle = GetAngle(x);
        int flipMod = LeftRigntMod(x);
        _ableToAttack = false;

        playerAnimator.FlipPlayer(x);
        playerAnimator.BlockFlip(0.45f);
        StartCoroutine(0.5f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle+(flipMod * 60), angle-(flipMod * 60), end));
        //return 1f;
    }
    //Удар 2
    public void Strike2()
    {
        playerAnimator.Strike2();
        strikeNum = 2;
        isNextStrike = false;
        strikeNumMod = 0.6f;
        float x = GetX();
        float angle = GetAngle(x);
        int flipMod = LeftRigntMod(x);

        playerAnimator.FlipPlayer(x);
        playerAnimator.BlockFlip(0.45f);
        StartCoroutine(0.5f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle - (flipMod * 60), angle + (flipMod * 60), end));
    }
    public void Strike3()
    {
        playerAnimator.Strike3();
        strikeNum = 3;
        isNextStrike = false;
        strikeNumMod = 1.3f;
        float x = GetX();
        float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - transform.position.y;
        float angle = GetAngle(x);

        //int mod = LeftRigntMod(x);
        _ableToAttack = false;
        playerAnimator.FlipPlayer(x);
        playerAnimator.BlockFlip(0.19f);

        int flipMod = LeftRigntMod(x);

        StartCoroutine(0.2f.Tweeng((u) => transform.localPosition = u, new Vector3(0, 0, 0), new Vector3(x * flipMod, y , 0).normalized / 5, end));
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    //Столкновение меча с чем-либо. С врагом-отталкивет, со стеной-пропадает.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            
            collision.GetComponent<AEnemy>().GetDamage(strikeNumMod * sword.damage * player.attack, 5 * (collision.transform.position - transform.position).normalized);
        }
        else if (collision.tag == "Wall")
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
            swordInHand.gameObject.SetActive(true);
            GetComponentInParent<AttackController>().SetSwordCoolDown(0.7f * (0.1f / player.attackCooldown));
>>>>>>> Stashed changes
=======
            swordInHand.gameObject.SetActive(true);
            GetComponentInParent<AttackController>().SetSwordCoolDown(0.7f * (0.1f / player.attackCooldown));
>>>>>>> Stashed changes
            SwordDisappear();
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
            //transform.rotation = Quaternion.Euler(0, 0, angle += 60);
            return 1;
        }

    }

}

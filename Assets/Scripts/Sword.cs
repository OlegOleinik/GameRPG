using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _ableToAttack = false;
    private SwordScriptableObject sword;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer sheath;
    private Player player;
    private GameManager.EndCorutine end;
    private float strikeNumMod;
    private int strikeNum = 0;

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
    private void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        end = EndStrike;
        gameObject.SetActive(false);
    }
    public void GetHideSword(bool isActive)
    {
        sheath.gameObject.SetActive(isActive);
    }

    public bool ableToAttack
    {
        get
        {
            return _ableToAttack;
        }
    }

    public void SetSword(SwordScriptableObject newSword)
    {
        sword = newSword;
        _ableToAttack = true;
        spriteRenderer.sprite = sword.itemSprite;
        sheath.sprite = sword.itemSprite;
    }
    private void EndStrike()
    {

        //Возможно, переписать
        if (isNextStrike && strikeNum < 3)
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
            
            GetComponentInParent<AttackController>().SetSwordCoolDown(0.7f * (0.1f / player.attackCooldown));
            SwordDisappear();
        }

    }

    //Пропажа меча и кулдаун атаки
    private void SwordDisappear()
    {
        transform.localPosition = Vector3.zero;

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
        strikeNum = 1;
        strikeNumMod = 1;
        float x = GetX();
        float angle = GetAngle(x);
        int mod = LeftRigntMod(x);
        _ableToAttack = false;
        StartCoroutine(0.5f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle+(mod*60), angle-(mod*60), end));
        //return 1f;
    }
    //Удар 2
    public void Strike2()
    {
        strikeNum = 2;
        isNextStrike = false;
        strikeNumMod = 0.6f;
        float x = GetX();
        float angle = GetAngle(x);
        int mod = LeftRigntMod(x);
        StartCoroutine(0.5f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle - (mod * 60), angle + (mod * 60), end));
    }
    public void Strike3()
    {
        strikeNum = 3;
        isNextStrike = false;
        strikeNumMod = 1.3f;
        float x = GetX();
        float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - transform.position.y;
        float angle = GetAngle(x);
        //int mod = LeftRigntMod(x);
        _ableToAttack = false;
        


        StartCoroutine(0.2f.Tweeng((u) => transform.localPosition = u, new Vector3(0,0,0), new Vector3(x, y, 0).normalized / 5, end));
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    //Столкновение меча с чем-либо. С врагом-отталкивет, со стеной-пропадает.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().AddForce(5*((collision.transform.position - transform.position).normalized), ForceMode2D.Impulse);
            collision.GetComponent<AEnemy>().GetDamage(strikeNumMod * sword.damage * player.attack);
        }
        else if (collision.tag == "Wall")
        {
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

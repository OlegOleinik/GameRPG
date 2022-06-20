using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private bool _isFlip = false;
    [SerializeField] private Animator legAnim;
    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator headAnim;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private SpriteRenderer sheath;
    [SerializeField] private SpriteRenderer swordInHand;
    [SerializeField] private Transform background;
    private SpriteRenderer[] spritesObjects;
    private float nextFlipTime;

    public bool isFlip
    {
        get
        {
            return _isFlip;
        }
    }
    void Start()
    {
        spritesObjects = new SpriteRenderer[] { legAnim.gameObject.GetComponent<SpriteRenderer>(), bodyAnim.gameObject.GetComponent<SpriteRenderer>(), headAnim.gameObject.GetComponent<SpriteRenderer>(), sheath, swordInHand};
        Idle();
        sheath.sortingOrder = 9;
    }

    public void Hit()
    {
        headAnim.SetInteger("State", 1);
    }

    public void HeadIdle()
    {
        headAnim.SetInteger("State", 0);
    }

    public void Walk()
    {
        legAnim.SetInteger("State", 4);
        if (bodyAnim.GetInteger("State") < 0)
        {
            bodyAnim.SetInteger("State", 4);
        }
    }

    public void Idle()
    {
        legAnim.SetInteger("State", 0);
        if (bodyAnim.GetInteger("State")>3)
        {
            bodyAnim.SetInteger("State", -1);

        }
    }

    public void Run()
    {
        legAnim.SetInteger("State", 5);
    }

    public void Strike1()
    {
        bodyAnim.SetInteger("State", 1);
    }

    public void Strike2()
    {
        bodyAnim.SetInteger("State", 2);
    }

    public void Strike3()
    {
        bodyAnim.SetInteger("State", 3);
    }

    public void MagicCast()
    {
        bodyAnim.Play("BodyMagicCast");   
    }

    public void ReadyWeapon()
    {
        bodyAnim.SetInteger("State", 0);
    }

    public void HideWeapon()
    {
        int i = legAnim.GetInteger("State");
        if (i != 0)
        {
            bodyAnim.SetInteger("State", i);
        }
        else
        {
            bodyAnim.SetInteger("State", -1);

        }
    }

    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

    public void FlipPlayer(float dir)
    {
        if (dir < 0 && !_isFlip && nextFlipTime < Time.time)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            _isFlip = true;
            sheath.sortingOrder = 12;
            background.localScale = new Vector3(-1 * background.localScale.x, background.localScale.y, 1);
            Camera.main.transform.localPosition = Vector3.Scale(Camera.main.transform.localPosition, new Vector3(-1, 1, 1));
        }
        else if (dir > 0 && _isFlip && nextFlipTime < Time.time)
        {
            gameObject.transform.localScale = Vector3.one;
            _isFlip = false;
            sheath.sortingOrder = 9;
            background.localScale = new Vector3(-1 * background.localScale.x, background.localScale.y, 1);
            Camera.main.transform.localPosition = Vector3.Scale(Camera.main.transform.localPosition, new Vector3(-1, 1, 1));
        }
    }

    public void HidePlayer(bool isHide)
    {
        foreach (var item in spritesObjects)
        {
            item.enabled = !isHide;
        }
        GameManager.player.GetComponent<AttackController>().SetSwordCoolDown(10 * System.Convert.ToInt32(isHide));
        GameManager.player.GetComponent<BoxCollider2D>().enabled = !isHide;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //private Animator playerAnimator;
    //private SpriteRenderer spriteRenderer;
    //private int state;
    //private float previosX;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private bool _isFlip = false;
=======
    private bool isFlip = false;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private bool isFlip = false;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private bool isFlip = false;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private bool isFlip = false;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private bool _isFlip = false;
>>>>>>> Stashed changes
=======
    private bool _isFlip = false;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    [SerializeField] private Animator legAnim;
    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator headAnim;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private SpriteRenderer sheath;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    [SerializeField] private SpriteRenderer swordInHand;
    private SpriteRenderer[] spritesObjects;
    private float nextFlipTime;
    //[SerializeField] private Animation walk;

    public bool isFlip
    {
        get
        {
            return _isFlip;
        }
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

    private float nextFlipTime;
    //[SerializeField] private Animation walk;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======

    private float nextFlipTime;
    //[SerializeField] private Animation walk;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======

    private float nextFlipTime;
    //[SerializeField] private Animation walk;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======

    private float nextFlipTime;
    //[SerializeField] private Animation walk;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //  previosX = GameManager.player.transform.position.x;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        spritesObjects = new SpriteRenderer[] { legAnim.gameObject.GetComponent<SpriteRenderer>(), bodyAnim.gameObject.GetComponent<SpriteRenderer>(), headAnim.gameObject.GetComponent<SpriteRenderer>(), sheath, swordInHand};
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
        spritesObjects = new SpriteRenderer[] { legAnim.gameObject.GetComponent<SpriteRenderer>(), bodyAnim.gameObject.GetComponent<SpriteRenderer>(), headAnim.gameObject.GetComponent<SpriteRenderer>(), sheath, swordInHand};
>>>>>>> Stashed changes
=======
        spritesObjects = new SpriteRenderer[] { legAnim.gameObject.GetComponent<SpriteRenderer>(), bodyAnim.gameObject.GetComponent<SpriteRenderer>(), headAnim.gameObject.GetComponent<SpriteRenderer>(), sheath, swordInHand};
>>>>>>> Stashed changes
        Idle();
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
        //legAnim.StartPlayback();
        legAnim.SetInteger("State", 1);
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Stashed changes

    public void Idle()
    {
        //legAnim.StopPlayback();
        legAnim.SetInteger("State", 0);
    }

    public void Run()
    {
        legAnim.SetInteger("State", 2);
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
        //bodyAnim.SetInteger("State", 3);
        bodyAnim.Play("BodyMagicCast");   
    }

    public void ReadyWeapon()
<<<<<<< Updated upstream
=======

    public void Idle()
    {
        //legAnim.StopPlayback();
        legAnim.SetInteger("State", 0);
    }

    public void Run()
    {
        legAnim.SetInteger("State", 2);
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
        //bodyAnim.SetInteger("State", 3);
        bodyAnim.Play("BodyMagicCast");   
    }

    public void ReadyWeapon()
    {
        bodyAnim.SetInteger("State", 0);
    }

    public void HideWeapon()
=======
    {
        bodyAnim.SetInteger("State", 0);
    }

    public void HideWeapon()
    {
        bodyAnim.SetInteger("State", -1);
    }

    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

    public void FlipPlayer(float dir)
>>>>>>> Stashed changes
    {
        bodyAnim.SetInteger("State", -1);
    }

<<<<<<< Updated upstream
    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

    public void FlipPlayer(float dir)
>>>>>>> Stashed changes
    {
        bodyAnim.SetInteger("State", 0);
    }

    public void HideWeapon()
    {
        bodyAnim.SetInteger("State", -1);
    }

    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

    public void FlipPlayer(float dir)
=======

    public void Idle()
    {
        //legAnim.StopPlayback();
        legAnim.SetInteger("State", 0);
    }

    public void Run()
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    {
=======

    public void Idle()
    {
        //legAnim.StopPlayback();
        legAnim.SetInteger("State", 0);
    }

    public void Run()
    {
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
        legAnim.SetInteger("State", 2);
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

<<<<<<< HEAD
<<<<<<< HEAD
        if (dir < 0 && !_isFlip && nextFlipTime < Time.time)
=======
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    public void MagicCast()
    {
        //bodyAnim.SetInteger("State", 3);
        bodyAnim.Play("BodyMagicCast");   
    }

    public void ReadyWeapon()
    {
        bodyAnim.SetInteger("State", 0);
    }

<<<<<<< Updated upstream
    public void HideWeapon()
    {
        bodyAnim.SetInteger("State", -1);
    }

    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

<<<<<<< HEAD
=======

    public void Idle()
    {
        //legAnim.StopPlayback();
        legAnim.SetInteger("State", 0);
    }

    public void Run()
    {
        legAnim.SetInteger("State", 2);
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

=======

    public void Idle()
    {
        //legAnim.StopPlayback();
        legAnim.SetInteger("State", 0);
    }

    public void Run()
    {
        legAnim.SetInteger("State", 2);
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

>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    public void MagicCast()
    {
        //bodyAnim.SetInteger("State", 3);
        bodyAnim.Play("BodyMagicCast");   
    }

    public void ReadyWeapon()
    {
        bodyAnim.SetInteger("State", 0);
    }

    public void HideWeapon()
    {
        bodyAnim.SetInteger("State", -1);
    }

    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

<<<<<<< HEAD
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    public void FlipPlayer(float dir)
    {

        if (dir < 0 && !isFlip && nextFlipTime < Time.time)
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
        if (dir < 0 && !_isFlip && nextFlipTime < Time.time)
>>>>>>> Stashed changes
=======
        if (dir < 0 && !_isFlip && nextFlipTime < Time.time)
>>>>>>> Stashed changes
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerCamera.transform.localPosition = new Vector3(0, 0, 10);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            _isFlip = true;
            sheath.sortingOrder = 11;
        }
        else if (dir > 0 && _isFlip && nextFlipTime < Time.time){
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
            isFlip = true;
            sheath.sortingOrder = 11;
        }
        else if (dir > 0 && isFlip && nextFlipTime < Time.time){
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
            isFlip = true;
            sheath.sortingOrder = 11;
        }
        else if (dir > 0 && isFlip && nextFlipTime < Time.time){
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> Stashed changes

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localPosition = new Vector3(0, 0, -10);
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
            _isFlip = false;
            sheath.sortingOrder = 9;
        }
=======

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localPosition = new Vector3(0, 0, -10);
            _isFlip = false;
            sheath.sortingOrder = 9;
        }
>>>>>>> Stashed changes
    }

    public void HidePlayer(bool isHide)
    {
        foreach (var item in spritesObjects)
        {
            item.enabled = !isHide;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
            isFlip = true;
            sheath.sortingOrder = 11;
=======
            isFlip = false;
            sheath.sortingOrder = 9;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
            isFlip = false;
            sheath.sortingOrder = 9;
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
        }
=======
            isFlip = true;
            sheath.sortingOrder = 11;
        }
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
        else if (dir > 0 && isFlip && nextFlipTime < Time.time){

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localPosition = new Vector3(0, 0, -10);
            isFlip = false;
            sheath.sortingOrder = 9;
<<<<<<< HEAD
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
        }
=======
        }
>>>>>>> Stashed changes
=======
        }
>>>>>>> Stashed changes
        GameManager.player.GetComponent<BoxCollider2D>().enabled = !isHide;
    }
    // Update is called once per frame

    //public void SetAnimation(int value)
    //{
    //    if (state != value)
    //    {
    //        playerAnimator.SetInteger("State", value);
    //        state = value;
    //    }

    //}


    //public void SetFlip(float x)
    //{

    //    if (x < 0 && spriteRenderer.flipX == false)
    //    {
    //        spriteRenderer.flipX = true;
    //        return;
    //    }
    //    else if (x > 0 && spriteRenderer.flipX == true)
    //    {
    //        spriteRenderer.flipX = false;
    //        return;
    //    }
    //}

}

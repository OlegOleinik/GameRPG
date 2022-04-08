using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //private Animator playerAnimator;
    //private SpriteRenderer spriteRenderer;
    //private int state;
    //private float previosX;
    private bool isFlip = false;
    // Start is called before the first frame update
    [SerializeField] private Animator legAnim;
    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator headAnim;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private SpriteRenderer sheath;

    private float nextFlipTime;
    //[SerializeField] private Animation walk;
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //  previosX = GameManager.player.transform.position.x;
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
    {
        bodyAnim.SetInteger("State", -1);
    }

    public void BlockFlip(float addTime)
    {
        nextFlipTime = Time.time + addTime;
    }

    public void FlipPlayer(float dir)
    {

        if (dir < 0 && !isFlip && nextFlipTime < Time.time)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerCamera.transform.localPosition = new Vector3(0, 0, 10);
            isFlip = true;
            sheath.sortingOrder = 11;
        }
        else if (dir > 0 && isFlip && nextFlipTime < Time.time){

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.localPosition = new Vector3(0, 0, -10);
            isFlip = false;
            sheath.sortingOrder = 9;
        }
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

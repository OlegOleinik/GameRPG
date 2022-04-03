using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    private int state;
    //private float previosX;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      //  previosX = GameManager.player.transform.position.x;
    }

    // Update is called once per frame

    public void SetAnimation(int value)
    {
        if (state != value)
        {
            playerAnimator.SetInteger("State", value);
            state = value;
        }

    }
    public void SetFlip(float x)
    {

        if (x < 0 && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
            return;
        }
        else if (x > 0 && spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
            return;
        }
    }

}

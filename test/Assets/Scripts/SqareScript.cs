using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqareScript : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2[] directions = new Vector2[] {
    Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    private KeyCode[] keys = new KeyCode[] { KeyCode.W,
    KeyCode.S, KeyCode.D, KeyCode.A };
    int dir = 2;
    float speed = 0.06f;
    // Start is called before the first frame update
    private Animator anim;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rigid.AddForce(new Vector2(20f, 20f), ForceMode2D.Force);
        }
    }
    void FixedUpdate()
    {
        
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKey(keys[i]))
            {
                if ((i==2) || (i==3))
                {
                    dir = i;
                }
                Move(i);
            }
        }
        if(dir==-1)
        {
            anim.speed = 0;
        }
        dir = -1;
    }
    private void Move(int i)
    {
        Vector3 go = Vector3.zero;
        go = directions[i];
        transform.position += go * speed;
        anim.CrossFade("PlayerGo" + dir, 0);
        anim.speed = 1;
    }

    public void ChangeSpeed(float s)
    {
        speed = s;
    }
}

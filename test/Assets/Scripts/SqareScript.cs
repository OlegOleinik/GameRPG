using System.Collections;
using System;
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
    bool ableToAttack;
    bool attack = false;
    int attackTic = 0;
    float coolDownAttack;
    // Start is called before the first frame update
    private Animator anim;
    GameObject sword;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sword = GameObject.Find("/Square/SwordBox");
        ableToAttack = true;
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    rigid.AddForce(new Vector2(20f, 20f), ForceMode2D.Force);
        //}
    }
    void FixedUpdate()
    {
        //Движение
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
        
        


        //Атака. Оптимизировать, вынести в отдельный метод/файл
        if (Input.GetKey(KeyCode.Mouse0) && (ableToAttack) && (Time.time > coolDownAttack))
        {
            float x = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float y = transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            float tg =y / x;
            float f = (float)Math.Atan(tg);
            //print(tg);
            sword.SetActive(true);
            Vector3 a = new Vector3(0, 0, 1);
            //sword.transform.Rotate(a, Convert.ToInt32(Math.Atan(tg)), Space.World);
            if (x<=0)
            {
                sword.transform.rotation = Quaternion.Euler(0f, 0f, f * (180 / (float)Math.PI)+55);
            }
            else
            {
                sword.transform.rotation = Quaternion.Euler(0f, 0f, 180+(f * (180 / (float)Math.PI))+55);
            }
            attack = true;
            ableToAttack = false;
            //sword.transform.rotation *= Quaternion.Euler(0f, 0f, -10f);

        }
        if(attack)
        {
            sword.transform.rotation *= Quaternion.Euler(0f, 0f, -10f);
            attackTic++;
            if (attackTic==11)
            {
                attackTic = 0;
                attack = false;
                ableToAttack = true;
                coolDownAttack = Time.time + 0.5f;
                sword.SetActive(false);
            }
        }

    }

    private void Attack()
    {
        

    }
    //private void OnMouseDown()
    //{
    //    if (sword.activeInHierarchy==false)
    //    {
    //        sword.SetActive(true);
    //    }
    //    else
    //    {
    //        sword.SetActive(false);
    //    }
        
    //}

        //Движение, перемещение и анимация
    private void Move(int i)
    {
        Vector3 go = Vector3.zero;
        go = directions[i];
        transform.position += go * speed;
        anim.CrossFade("PlayerGo" + dir, 0);
        anim.speed = 1;
    }

    //Смена скорости. В воде например
    public void ChangeSpeed(float s)
    {
        speed = s;
    }
}

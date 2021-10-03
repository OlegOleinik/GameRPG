using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    //ПРИВЯЗАТЬ ПЕРВИЧНЫЙ СПАВН К МЕТОДУ СПАВН


    //Некоторое необходимо переопределить в классе противника

    //В ДАННЫЙ МОМЕНТ НЕ ВСЕ ПЕРЕМННЫЕ ПЕРЕОПРЕДЕЛЯЮТСЯ. СКОРОСТЬ ИСПРАВИТЬ
    protected float speed=200f;
    protected GameObject target;
    public float x, y;
    protected int HP, maxHP;

    Vector3 targetPoint;
    Rigidbody2D rigidbod;
    protected Vector2 spawnPosition;
    protected Color colorChange;
    protected bool isDie = false;
    float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(spawnPosition);
        if ((isDie) && (respawnTime < Time.time))
        {
            Respawn();
        }
        else if(!isDie)
        {
            Move();
        }
       

    }

    private void FixedUpdate()
    {
        
        
        
    }
    //Движение.
    protected void Move()
    {
        rigidbod = GetComponent<Rigidbody2D>();
        //x = target.transform.position.x;
        //y = target.transform.position.y;
        //float xTP = transform.position.x - x;
        //float yTP = transform.position.y - y;
        //Vector3 targetPoint = new Vector3(xTP/Math.Abs(xTP),yTP/Math.Abs(yTP));


        //transform.position -= targetPoint * speed;
        //print(targetPoint.x);
        Vector2 velocity = new Vector2(0.03f, 0.03f);
        targetPoint = target.transform.position;
        //rigidbod.MovePosition(targetPoint*velocity);
        rigidbod.AddForce((targetPoint - transform.position).normalized * speed * Time.deltaTime, ForceMode2D.Force);
        //rigidbod.fo
    }

    //Респавн
    protected void Respawn()
    {
        HP = maxHP;
        transform.position = spawnPosition;
        //gameObject.SetActive(true);
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = true;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color -= colorChange*maxHP;
        sprite.color += new Color(0, 0, 0, 1);
        isDie = false;
    }
    //Получение урона
    public void GetDamage()
    {
        HP--;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color += colorChange;
        if (HP==0)
        {
            Die();
        }
    }
    //Смерть противника
    private void Die()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        isDie = true;
        respawnTime = Time.time + 5;



        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color += new Color(0, 0, 0, -1);
    }
}

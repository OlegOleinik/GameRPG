using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //При прикосновении к мечу происходит отталкивание и урон
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionWith = collision.gameObject;
        if (collisionWith.tag == "Enemy")
        {
            //SqareScript squareScript = collisionWith.GetComponent<SqareScript>();
            //squareScript.ChangeSpeed(0.03f);

            Enemy enemy = collisionWith.GetComponent<Enemy>();
            Rigidbody2D rigid = collisionWith.GetComponent<Rigidbody2D>();
            rigid.AddForce(new Vector2(10*(collisionWith.transform.position.x-transform.position.x), 10*(collisionWith.transform.position.y - transform.position.y)), ForceMode2D.Impulse);
            enemy.GetDamage();
        }
    }
}

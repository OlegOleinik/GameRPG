using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spell : MonoBehaviour
{
    float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>coolDown)
        {
            gameObject.SetActive(false);
        }
    }
    public void Fire(float xStart, float yStart, float xTarget, float yTarget)
    {
        
        transform.position = new Vector3(xStart, yStart, -1);
        gameObject.SetActive(true);

        float x = xStart - xTarget;
        float y = yStart - yTarget;
        float tg = y / x;
        float f = (float)Math.Atan(tg);
        if (x <= 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, f * (180 / (float)Math.PI));
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180 + (f * (180 / (float)Math.PI)));
        }
        coolDown = Time.time + 1;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionWith = collision.gameObject;
        if (collisionWith.tag == "Enemy")
        {
            Enemy enemy = collisionWith.GetComponent<Enemy>();
            enemy.GetDamage();
            gameObject.SetActive(false);
        }
        else if (collisionWith.tag != "Player")
        {
            gameObject.SetActive(false);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.moveSpeed /= 2;
            collision.GetComponent<Rigidbody2D>().mass *= 5;
        }
        else if (collision.tag == "Enemy")
        {
            AEnemy enemy = collision.GetComponent<AEnemy>();
            enemy.speed /= 2;
            collision.GetComponent<Rigidbody2D>().mass *= 5;
        }
    }
    //Конец касания воды
   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.moveSpeed *= 2;
            collision.GetComponent<Rigidbody2D>().mass /= 5;
        }
        else if (collision.tag == "Enemy")
        {
            AEnemy enemy = collision.GetComponent<AEnemy>();
            enemy.speed *= 2;
            collision.GetComponent<Rigidbody2D>().mass /= 5;
        }
    }
}
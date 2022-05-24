using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour
{
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
            enemy.WaterCollisionEnter();
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
            enemy.WaterCollisionExit();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRicochetSpell : ASpell
{
    // Start is called before the first frame update
    public override void Start()
    {
        transform.position = GameManager.player.transform.position;
    }
    public override void Spell()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<AEnemy>().GetDamage(1);
            Destroy(gameObject);
        }
        else if (collision.tag == "Wall")
        {
           // Vector2.Reflect(gameObject.transform.position, collision.)
        }

    }
}

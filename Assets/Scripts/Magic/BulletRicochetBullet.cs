using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BulletRicochetBullet : MonoBehaviour
{
    private float timer;
    private float baseDamage = 0.2f;
    private float lvlMod;
    public void Start()
    {

        DontDestroyOnLoad(gameObject);
        transform.position = GameManager.player.transform.position;
    }

    private void Update()
    {
        if (timer < Time.time)
        {
            Destroy(gameObject);
        }

    }
    public void Shoot(float lvlMod, float time)
    {
        float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
        float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        timer = Time.time + time;
        this.lvlMod = lvlMod;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float speedMod = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            float damage = baseDamage * speedMod * 0.5f;
            collision.gameObject.GetComponent<AEnemy>().GetDamage((damage * GameManager.player.GetComponent<Player>().magicDamage) + (damage * lvlMod));
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[10];
            collision.GetContacts(contacts);

            Vector3 currentBulletMoveVector = transform.right;
            Vector2 newBulletMoveVector = Vector2.Reflect(currentBulletMoveVector, contacts[0].normal);

            transform.right = new Vector3(newBulletMoveVector.x, newBulletMoveVector.y, 0);
        }
    }
}

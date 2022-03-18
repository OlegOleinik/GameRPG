using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRicochetSpell : ASpell
{
    // Start is called before the first frame update

    [SerializeField] private GameObject bullet;
    public override void Start()
    {
        transform.position = GameManager.player.transform.position;
        transform.SetParent(GameManager.player.transform);
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //gameObject.GetComponent<ConstantForce2D>().enabled = false;
    }
    private void Update()
    {

        //if (timer<Time.time)
        //{
        //    Destroy(gameObject);
        //}
    }
    public override void Spell()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<BulletRicochetBullet>().Shoot();
        //Instantiate(gameObject);
       

        // transform.right = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameManager.player.transform.position);
        
        //transform.forward = new Vector3(0.5f, 1, 1);
    }

    //public void Shoot()
    //{
    //    GetComponent<BoxCollider2D>().enabled = true;
    //    GetComponent<ConstantForce2D>().enabled = true;
    //    float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameManager.player.transform.position.x;
    //    float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - GameManager.player.transform.position.y, x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, angle);
    //    timer = Time.time + 10f;

    //    StartCoroutine(DisappearBullet());
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        float speedMod = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
    //        //Debug.Log(a);
    //        collision.gameObject.GetComponent<AEnemy>().GetDamage(0.2f* speedMod*GameManager.player.GetComponent<Player>().magicDamage);
    //        Destroy(gameObject);
    //    }
    //    else if (collision.gameObject.tag == "Wall")
    //    {
    //        ContactPoint2D[] contacts = new ContactPoint2D[10];
    //        collision.GetContacts(contacts);

    //        Vector3 currentBulletMoveVector = transform.right;
    //        Vector2 newBulletMoveVector = Vector2.Reflect(currentBulletMoveVector, contacts[0].normal);

    //        transform.right = new Vector3(newBulletMoveVector.x, newBulletMoveVector.y, 0);

    //        // transform.forward
    //        //  transform.rotation = Quaternion.Euler(0, 0, angle);
    //    }
    //}

    //IEnumerator DisappearBullet()
    //{
    //    while (timer > Time.time)
    //    {
    //        yield return null;
    //    }
    //    Destroy(gameObject);
    //    //gameObject.SetActive(false);
    //}

}

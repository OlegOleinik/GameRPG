using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _ableToAttack = true;
    private SwordScriptableObject sword;
    private SpriteRenderer spriteRenderer;
    private Player player;
    private GameManager.EndCorutine end;
    private void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        end = SwordDisappear;
        gameObject.SetActive(false);
    }

    public bool ableToAttack
    {
        get
        {
            return _ableToAttack;
        }
    }

    public void SetSword(SwordScriptableObject newSword)
    {
        sword = newSword;
        spriteRenderer.sprite = sword.itemSprite;
    }

    //Пропажа меча и кулдаун атаки
    private void SwordDisappear()
    {
        gameObject.SetActive(false);
        _ableToAttack = true;
    }
    private float GetX()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
    }
    private float GetAngle(float x)
    {
        
        return Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, x) * Mathf.Rad2Deg;
    }
    //Удар 1
    public float Strike1()
    {
        float x = GetX();
        float angle = GetAngle(x);
        int mod = LeftRigntMod(x);
        _ableToAttack = false;
        //StartCoroutine(RotateObject());
        StartCoroutine(0.7f.Tweeng((u) => transform.rotation = Quaternion.Euler(0, 0, u), angle+(mod*60), angle-(mod*60), end));
        return 0.5f;
    }
    //Удар 2
    public void Strike2()
    {

    }

    //Столкновение меча с чем-либо. С врагом-отталкивет, со стеной-пропадает.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().AddForce(5*((collision.transform.position - transform.position).normalized), ForceMode2D.Impulse);
            collision.GetComponent<AEnemy>().GetDamage(System.Convert.ToInt32(Mathf.Round(1 * player.attack)));
        }
        else if (collision.tag == "Wall")
        {
            SwordDisappear();
        }
    }

    private int LeftRigntMod(float x)
    {
        if (x < 0)
        {
            return -1;
        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 0, angle += 60);
            return 1;
        }

    }

    //private float GetStartPoint(float x, float angle)
    //{
    //    float startAngle;
    //   // float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;

    //    if (x < 0)
    //    {
    //        // transform.rotation = Quaternion.Euler(0, 0, angle -= 60);
    //        startAngle = angle -= 60;
    //    }
    //    else
    //    {
    //        //transform.rotation = Quaternion.Euler(0, 0, angle += 60);
    //        startAngle = angle += 69;
    //    }
    //    return startAngle;
    //}
    //    private float GetEndPoint()
    //     {
    //    float endingAngle;
    //    _ableToAttack = false;
    //    float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
    //    float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, x) * Mathf.Rad2Deg;

    //    if (x < 0)
    //    {
    //        //transform.rotation = Quaternion.Euler(0, 0, angle -= 60);
    //        endingAngle = angle += 60;
    //    }
    //    else
    //    {
    //        //transform.rotation = Quaternion.Euler(0, 0, angle += 60);
    //        endingAngle = angle -= 60;
    //    }
    //    Debug.Log(angle);
    //    return angle;
    //}
    //Вращение меча. ЕСЛИ x < 0, т.е. удар слева от игрока, то оклонение в минус и движение в +. Для того, чтобы взмах всегда был сверху вниз
    //IEnumerator RotateObject()
    //{
    //    Quaternion endingAngle;
    //    float moveSpeed = 450;
    //    _ableToAttack = false;


    //    float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
    //    float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, x) * Mathf.Rad2Deg;

    //    if (x<0)
    //    {
    //        transform.rotation = Quaternion.Euler(0, 0, angle -= 60);
    //        endingAngle = Quaternion.Euler(0, 0, angle + 120);
    //    }
    //    else
    //    {
    //        transform.rotation = Quaternion.Euler(0, 0, angle += 60);
    //        endingAngle = Quaternion.Euler(0, 0, angle - 120);
    //    }
        

    //    while (Quaternion.Angle(transform.rotation, endingAngle) > 0.01)
    //    {
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
    //        yield return null;
    //    }
    //    transform.rotation = endingAngle;
    //    SwordDisappear();
    //}
}

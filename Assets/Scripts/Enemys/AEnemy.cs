using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour, IMoveable, IDamagable, IDieable
{

    public float speed;
    public int maxHP;
    //public float viewDistance;
    public float dropedExperience;
    [SerializeField] private float attack;


    [SerializeField] private DropedItem dropedItem;
    private Transform targetPlayer;
    private Vector2 targetPoint;
    private Vector2 spawnPosition;
    private float _currentHP;
    private float vaitTime=-1;
    private Rigidbody2D rb;

    private LayerMask layerMask;

    [SerializeField] private List<ItemScriptableObject> DropList;
    [SerializeField] private List<float> DropChanceList;
    [SerializeField] private Animator enemyAnimator;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private GameObject healthBar;

    private float _nextDamage = 0;

=======
    private float _nextDamage = 0;

>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private float _nextDamage = 0;

>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private float _nextDamage = 0;

>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private float _nextDamage = 0;

>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    public float nextDamage
    {
        get
        {
            return _nextDamage;
        }
    }
    public float currentHP
    {
        get
        {
            return _currentHP;
        }
    }
    //Ищет игрока, сохраняет позицию спавна, маски для Raycast, задает текущее здоровье максимальным.
    private void Start()
    {
        targetPlayer = GameManager.player.transform;
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = rb.position;
        targetPoint = spawnPosition;
        _currentHP = maxHP;
        layerMask = LayerMask.GetMask("Wall")+ LayerMask.GetMask("Player");

        healthBar = GetComponentInChildren<HealthBar>().gameObject;
    }
    //Выбросить предметы, согласну шансу выпадения
    private void DropItems()
    {
        for (int i=0; i<DropList.Count && i< DropChanceList.Count; i++)
        {
            if (Random.Range(0f,1f)<DropChanceList[i])
            {
                dropedItem.DropItem(DropList[i], transform.position);
            }
        }
    }
    //Умереть(( Добавить опыт игроку, уничтожиться, бросить предметы
    public void Die()
    {
        targetPlayer.gameObject.GetComponent<Player>().AddExperience(dropedExperience);
        Destroy(gameObject);
        DropItems();
    }
    //Получить урон, если ХП меньше/равно 0-умереть
    public void GetDamage(float damage, Vector2 force)
    {
        if (nextDamage < Time.time)
        {
            LostHP(damage);
            GetForce(force);
            SetDamageCoolDown(0.5f);
            if (_currentHP <= 0)
            {
                Die();
            }
        }

    }
    public void GetDamage(float damage)
    {
        if (nextDamage < Time.time)
        {
            LostHP(damage);
            SetDamageCoolDown(0.5f);
            if (_currentHP <= 0)
            {
                Die();
            }
        }
    }

    public void LostHP(float damage)
    {
        _currentHP -= damage;
    }

    public void GetForce(Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }



    private void SetFlip(float x)
    {
        if (x > 0)
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
=======
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
=======
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
        }
        else if (x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
        }
        else if (x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        healthBar.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }
    //ЕСЛИ дистанция до точки спавна > 10, цель движения-точка спавна, иначе если виден игрок и целевая точка-не точка спавна-преследовать игрока, иначе свободно ходить
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if ((Vector2.Distance(spawnPosition, transform.position) > 10))
        {
            _currentHP = maxHP;
            targetPoint = spawnPosition;
            MoveToPos(targetPoint);
        }
        else if (IsSeen() && targetPoint != spawnPosition)
        {
            targetPoint = targetPlayer.position;
            MoveToPos(targetPoint);
        }
        else
        {
            DefaultWalk();
        }
    }

    //Переместить врага к целевой точке
    private void MoveToPos(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
        SetFlip(position.x - transform.position.x);
        enemyAnimator.SetInteger("State", 1);
    }

    //Проверка видимости игрока, противник видит слой стен и игрока (заданы в Start), но true, только когда виден игрок
    private bool IsSeen()
    {
        Debug.DrawRay(transform.position, (targetPlayer.position - transform.position).normalized *5, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (targetPlayer.position - transform.position).normalized, 5, layerMask);
        if ((hit) && (hit.collider.tag != "Wall"))
        {
            return true;
        }
        return false;
    }

    //Свободное хождение. Если целевая точне не равна текущей-двигаться к ней. ИНАЧЕ, ЕСЛИ время ожидания -1, задать время 1 сек, ИНАЧЕ ЕСЛИ время ожидания больше текущего, задать новую целевую точку.
    //Если время ожидания меньше текущего и не -1, ничего не происходит (противник стоит)
    private void DefaultWalk()
    {
        if (rb.position!=targetPoint)
        {
            MoveToPos(targetPoint);
        }
        else
        {
            enemyAnimator.SetInteger("State", 0);
            if (vaitTime == -1)
            {
                vaitTime = Time.time + 1;
            }
            else if (vaitTime < Time.time)
            {
                    targetPoint = SetRandomTargetPoint();
                    vaitTime = -1;
            }
            
        }
    }
    //Ставит рандомную целевую точку в круге радиуса 5 вокруг точки спавна
    private Vector2 SetRandomTargetPoint()
    {
        return (Random.insideUnitCircle * 5) + spawnPosition;
    }

    //При столкновении со стеной выбрать новую целевую точку. Используется именно Stay, т.к. при Enter все еще может застрять
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            targetPoint = SetRandomTargetPoint();
        }
    }

    //При столкновении с игроком вызывает его метод получения урона
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionWith = collision.gameObject;
        if (collisionWith.tag == "Player")
        {
            collisionWith.GetComponent<Player>().GetDamage(attack);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour, IMoveable, IDamagable, IDieable
{
    public string enemyName;
    public float speed;
    public int maxHP;
    public float dropedExperience;
    [SerializeField] protected float attack;
    [SerializeField] protected float repulsion = 1;
    [SerializeField] GameObject particlesOnDamage;
    [SerializeField] private DropedItem dropedItem;
    public Vector2 targetPoint;
    public Vector2 spawnPosition;
    protected float _currentHP;
    protected float vaitTime=-1;
    public Rigidbody2D rb;
    public float seenDistance = 5;
    private LayerMask layerMask;
    [SerializeField] protected List<ItemScriptableObject> DropList;
    [SerializeField] protected List<float> DropChanceList;
    [SerializeField] protected Animator enemyLegAnimator;
    [SerializeField] protected GameObject healthBar;
    private float _nextDamage = 0;
    [SerializeField] private FieldOfView fieldOfView;
    protected bool isSeen = false;
    protected List<Transform> targetList = new List<Transform>();
    [SerializeField] protected AudioSource audioSource;

    private const float NEXTDAMAGECD = 0.5f;


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

    public float getAttack
    {
        get
        {
            return attack;
        }
    }

    public float getRepulsion
    {
        get
        {
            return repulsion;
        }
    }
    public virtual void Start()
    {
        if (fieldOfView != null)
        {
            fieldOfView.SetCircleRadius(seenDistance, this);
        }
        spawnPosition = transform.position;
        targetPoint = spawnPosition;
        _currentHP = maxHP;
        layerMask = LayerMask.GetMask("Wall") + LayerMask.GetMask("Player") + LayerMask.GetMask("Enemys");
        GameManager.OnGamePause += PauseSound;
        GameManager.OnGameResume += ResumeSound;
    }

    protected virtual void DamageParticles()
    {
        Instantiate(particlesOnDamage, gameObject.transform.position, Quaternion.identity);
    }

    //Выбросить предметы, согласну шансу выпадения
    protected void DropItems()
    {
        for (int i=0; i<DropList.Count && i< DropChanceList.Count; i++)
        {
            if (Random.Range(0f,1f)<DropChanceList[i])
            {
                dropedItem.DropItem(DropList[i], transform.position);
            }
        }
    }

    private void PauseSound()
    {
        audioSource.Pause();
    }

    private void ResumeSound()
    {
        audioSource.UnPause();
    }
   
    public virtual void Die()
    {
        Disappear();
    }

    //Умереть(( Добавить опыт игроку, уничтожиться, бросить предметы
    public virtual void Disappear()
    {
        GameManager.player.GetComponent<Player>().AddExperience(dropedExperience);

        Destroy(gameObject);
        DieEvent();
        DropItems();
    }

    public abstract void DieEvent();
    //Получить урон, если ХП меньше/равно 0-умереть
    public virtual void GetDamage(float damage, Vector2 force)
    {
        if (nextDamage < Time.time)
        {
            LostHP(damage);
            GetForce(force);
            SetDamageCoolDown(NEXTDAMAGECD);
            if (_currentHP <= 0)
            {
                Die();
            }
        }
    }
    public virtual void GetDamage(float damage)
    {
        if (nextDamage < Time.time)
        {
            LostHP(damage);
            SetDamageCoolDown(NEXTDAMAGECD);
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

    public virtual void GetForce(Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    protected virtual void SetFlip(float x)
    {
        if (x > 0)
        {
            gameObject.transform.localScale = Vector3.one;
            healthBar.transform.localScale = new Vector3(1, 0.13f, 1);
            return;
        }
        else if (x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            healthBar.transform.localScale = new Vector3(-1, 0.13f, 1);
        }
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }
    //ЕСЛИ дистанция до точки спавна > 10, цель движения-точка спавна, иначе если виден игрок и целевая точка-не точка спавна-преследовать игрока, иначе свободно ходить
    protected virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        if ((Vector2.Distance(spawnPosition, transform.position) > 10))
        {
            _currentHP = maxHP;
            targetPoint = spawnPosition;
            MoveToPos(targetPoint);
        }
        else if (isSeen && IsSeen(targetList[0]) && targetPoint != spawnPosition)
        {
            targetPoint = targetList[0].position;
            MoveToPos(targetPoint);
        }
        else
        {
            DefaultWalk();
        }
    }

    protected virtual void MoveToPos(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
        SetFlip(position.x - transform.position.x);
    }

    //Проверка видимости игрока, противник видит слой стен и игрока (заданы в Start), но true, только когда виден игрок
    protected virtual bool IsSeen(Transform target)
    {
        if (target == null)
        {
            targetList.RemoveAt(0);
            return false;
        }
        Debug.DrawRay(transform.position, (target.position - transform.position).normalized * seenDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (target.position - transform.position).normalized, seenDistance, layerMask);
        if ((hit) && (hit.collider.tag != "Wall"))
        {
            return true;
        }
        return false;
    }

    //Свободное хождение. Если целевая точне не равна текущей-двигаться к ней. ИНАЧЕ, ЕСЛИ время ожидания -1, задать время 1 сек, ИНАЧЕ ЕСЛИ время ожидания больше текущего, задать новую целевую точку.
    //Если время ожидания меньше текущего и не -1, ничего не происходит (противник стоит)
    protected virtual void DefaultWalk()
    {

    }
    //Ставит рандомную целевую точку в круге радиуса 5 вокруг точки спавна
    public Vector2 SetRandomTargetPoint()
    {
        return (Random.insideUnitCircle * 5) + spawnPosition;
    }

    //При столкновении со стеной выбрать новую целевую точку. Используется именно Stay, т.к. при Enter все еще может застрять
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            targetPoint = SetRandomTargetPoint();
        }
    }

    //При столкновении с игроком вызывает его метод получения урона
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if ((gameObject.tag != collision.gameObject.tag) && (targetList.Count > 0))
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.GetDamage(attack, repulsion * 100 * (collision.transform.position - transform.position).normalized);
                AttackAnimation();
            }
        }
    }

    public virtual void AddTarget(GameObject newTarget)
    {
        if(newTarget.tag == "Player" || newTarget.tag == "NPC")
        {
            targetList.Add(newTarget.transform);
            isSeen = true;
        }
    }

    public virtual void RemoveTarget(GameObject lostTarget)
    {
        if (lostTarget.tag == "Player" || lostTarget.tag == "NPC")
        {
            targetList.Remove(lostTarget.transform);
            if (targetList.Count < 1)
            {
                isSeen = false;
            }
        }
    }

    public virtual void WaterCollisionEnter()
    {
        speed /= 2;
        GetComponent<Rigidbody2D>().mass *= 5;
    }

    public virtual void WaterCollisionExit()
    {
        speed *= 2;
        GetComponent<Rigidbody2D>().mass /= 5;
    }
    protected virtual void AttackAnimation()
    {

    }

    protected virtual void OnDestroy()
    {
        GameManager.OnGamePause -= PauseSound;
        GameManager.OnGameResume -= ResumeSound;
    }
}

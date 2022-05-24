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
<<<<<<< Updated upstream
    private Transform targetPlayer;
    public Vector2 targetPoint;
    public Vector2 spawnPosition;
    private float _currentHP;
    private float vaitTime=-1;
    public Rigidbody2D rb;
    

=======
    public Vector2 targetPoint;
    public Vector2 spawnPosition;
    protected float _currentHP;
    protected float vaitTime=-1;
    public Rigidbody2D rb;
    public float seenDistance = 5;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    [SerializeField] private List<ItemScriptableObject> DropList;
    [SerializeField] private List<float> DropChanceList;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] private Animator enemyAnimator;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    [SerializeField] private Animator enemyLegAnimator;
=======
    public float nextDamage
    {
        get
        {
            return _nextDamage;
        }
    }
>>>>>>> Stashed changes

>>>>>>> Stashed changes
    private GameObject healthBar;

    private float _nextDamage = 0;

<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
=======
    [SerializeField] private Animator enemyLegAnimator;

    private GameObject healthBar;

    private float _nextDamage = 0;

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        layerMask = LayerMask.GetMask("Wall")+ LayerMask.GetMask("Player");

        healthBar = GetComponentInChildren<HealthBar>().gameObject;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        SetStart();
    }


    public virtual void SetStart()
    {

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
        layerMask = LayerMask.GetMask("Wall") + LayerMask.GetMask("Player") + LayerMask.GetMask("Enemys");
        GameManager.OnGamePause += PauseSound;
        GameManager.OnGameResume += ResumeSound;
    }

    protected virtual void DamageParticles()
    {
        Instantiate(particlesOnDamage, gameObject.transform.position, Quaternion.identity);
>>>>>>> Stashed changes
    }

    //��������� ��������, �������� ����� ���������
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

    //�������(( �������� ���� ������, ������������, ������� ��������
<<<<<<< Updated upstream
    public void Die()
=======
    public virtual void Disappear()
>>>>>>> Stashed changes
    {
        GameManager.player.GetComponent<Player>().AddExperience(dropedExperience);

        Destroy(gameObject);
        DieEvent();
        DropItems();
    }

<<<<<<< Updated upstream

    public abstract void DieEvent();
    //�������� ����, ���� �� ������/����� 0-�������
    public void GetDamage(float damage, Vector2 force)
=======
    public abstract void DieEvent();
    //�������� ����, ���� �� ������/����� 0-�������
    public virtual void GetDamage(float damage, Vector2 force)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

    }
    public void GetDamage(float damage)
=======
    }
    public virtual void GetDamage(float damage)
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
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    public void GetForce(Vector2 force)
=======
    public virtual void GetForce(Vector2 force)
>>>>>>> Stashed changes
    {
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

<<<<<<< Updated upstream


    private void SetFlip(float x)
    {
        if (x > 0)
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0)
        {
>>>>>>> Stashed changes
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
=======
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
=======
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
>>>>>>> Stashed changes
        }
>>>>>>> Stashed changes
        healthBar.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    private void SetDamageCoolDown(float addCD)
    {
        _nextDamage = Time.time + addCD;
    }
    //���� ��������� �� ����� ������ > 10, ���� ��������-����� ������, ����� ���� ����� ����� � ������� �����-�� ����� ������-������������ ������, ����� �������� ������
    protected virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        Move();
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public void Move()
=======
    public virtual void Move()
>>>>>>> Stashed changes
=======
    public virtual void Move()
>>>>>>> Stashed changes
    {
        if ((Vector2.Distance(spawnPosition, transform.position) > 10))
        {
            _currentHP = maxHP;
            targetPoint = spawnPosition;
            MoveToPos(targetPoint);
        }
<<<<<<< Updated upstream
        else if (IsSeen() && targetPoint != spawnPosition)
        {
            targetPoint = targetPlayer.position;
=======
        else if (isSeen && IsSeen(targetList[0]) && targetPoint != spawnPosition)
        {
            targetPoint = targetList[0].position;
>>>>>>> Stashed changes
            MoveToPos(targetPoint);
        }
        else
        {
            DefaultWalk();
        }
    }

<<<<<<< Updated upstream
    //����������� ����� � ������� �����
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private void MoveToPos(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
        SetFlip(position.x - transform.position.x);
        enemyAnimator.SetInteger("State", 1);
=======
    public virtual void MoveToPos(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
        SetFlip(position.x - transform.position.x);
        SetLegAnim(1);
>>>>>>> Stashed changes
=======
    public virtual void MoveToPos(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
        SetFlip(position.x - transform.position.x);
        SetLegAnim(1);
>>>>>>> Stashed changes
=======
    protected virtual void MoveToPos(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
        SetFlip(position.x - transform.position.x);
>>>>>>> Stashed changes
    }
    public virtual void SetLegAnim(int i)
    {
        enemyLegAnimator.SetInteger("State", i);

    }
    //�������� ��������� ������, ��������� ����� ���� ���� � ������ (������ � Start), �� true, ������ ����� ����� �����
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

    //��������� ��������. ���� ������� ����� �� ����� �������-��������� � ���. �����, ���� ����� �������� -1, ������ ����� 1 ���, ����� ���� ����� �������� ������ ��������, ������ ����� ������� �����.
    //���� ����� �������� ������ �������� � �� -1, ������ �� ���������� (��������� �����)
<<<<<<< Updated upstream
    public virtual void DefaultWalk()
    {
        if (rb.position!=targetPoint)
        {
            MoveToPos(targetPoint);
        }
        else
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            enemyAnimator.SetInteger("State", 0);
=======
            SetLegAnim(0);
>>>>>>> Stashed changes
=======
            SetLegAnim(0);
>>>>>>> Stashed changes
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
=======
    protected virtual void DefaultWalk()
    {

>>>>>>> Stashed changes
    }
    //������ ��������� ������� ����� � ����� ������� 5 ������ ����� ������
    public Vector2 SetRandomTargetPoint()
    {
        return (Random.insideUnitCircle * 5) + spawnPosition;
    }

    //��� ������������ �� ������ ������� ����� ������� �����. ������������ ������ Stay, �.�. ��� Enter ��� ��� ����� ��������
<<<<<<< Updated upstream
    public virtual void OnCollisionStay2D(Collision2D collision)
=======
    protected virtual void OnCollisionStay2D(Collision2D collision)
>>>>>>> Stashed changes
    {
        if (collision.gameObject.tag == "Wall")
        {
            targetPoint = SetRandomTargetPoint();
        }
    }

    //��� ������������ � ������� �������� ��� ����� ��������� �����
<<<<<<< Updated upstream
    public virtual void OnCollisionEnter2D(Collision2D collision)
=======
    protected virtual void OnCollisionEnter2D(Collision2D collision)
>>>>>>> Stashed changes
    {
        if ((gameObject.tag != collision.gameObject.tag) && (targetList.Count > 0))
        {
<<<<<<< Updated upstream
            collisionWith.GetComponent<Player>().GetDamage(attack);
            targetPoint = targetPlayer.position;
            AttackAnimation();
        }
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
    public virtual void AttackAnimation()
    {

    }

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

=======
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
>>>>>>> Stashed changes
}

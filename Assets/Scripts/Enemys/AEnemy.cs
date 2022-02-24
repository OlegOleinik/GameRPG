using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
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
    private int _currentHP;
    private float vaitTime=-1;
    private Rigidbody2D rb;

    private LayerMask layerMask;

    [SerializeField] private List<ItemScriptableObject> DropList;
    [SerializeField] private List<float> DropChanceList;


    public int currentHP
    {
        get
        {
            return _currentHP;
        }
    }
    //���� ������, ��������� ������� ������, ����� ��� Raycast, ������ ������� �������� ������������.
    private void Start()
    {
        targetPlayer = GameManager.player.transform;
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = rb.position;
        targetPoint = spawnPosition;
        _currentHP = maxHP;
        layerMask = LayerMask.GetMask("Wall")+ LayerMask.GetMask("Player");
    }
    //��������� ��������, �������� ����� ���������
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
    //�������(( �������� ���� ������, ������������, ������� ��������
    private void Die()
    {
        targetPlayer.gameObject.GetComponent<Player>().AddExperience(dropedExperience);
        Destroy(gameObject);
        DropItems();
    }
    //�������� ����, ���� �� ������/����� 0-�������
    public void GetDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Die();
        }
    }
    //���� ��������� �� ����� ������ > 10, ���� ��������-����� ������, ����� ���� ����� ����� � ������� �����-�� ����� ������-������������ ������, ����� �������� ������
    private void FixedUpdate()
    {
        if ((Vector2.Distance(spawnPosition, transform.position) > 10))
        {
            _currentHP = maxHP;
            targetPoint = spawnPosition;
            Move(targetPoint);
        }
        else if (IsSeen() && targetPoint!=spawnPosition)
        {
            targetPoint = targetPlayer.position;
            Move(targetPoint);
        }
        else
        {
            DefaultWalk();
        }
    }


    //����������� ����� � ������� �����
    private void Move(Vector2 position)
    {
        rb.position = Vector2.MoveTowards(transform.position, position, speed);
    }

    //�������� ��������� ������, ��������� ����� ���� ���� � ������ (������ � Start), �� true, ������ ����� ����� �����
    private bool IsSeen()
    {
        Debug.DrawRay(transform.position, (targetPlayer.position - transform.position).normalized *5, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (targetPlayer.position - transform.position).normalized, 5, layerMask);
        if ((hit) && (hit.collider.tag == "Player"))
        {
            return true;
        }
        return false;
    }

    //��������� ��������. ���� ������� ����� �� ����� �������-��������� � ���. �����, ���� ����� �������� -1, ������ ����� 1 ���, ����� ���� ����� �������� ������ ��������, ������ ����� ������� �����.
    //���� ����� �������� ������ �������� � �� -1, ������ �� ���������� (��������� �����)
    private void DefaultWalk()
    {
        if (rb.position!=targetPoint)
        {
            Move(targetPoint);
        }
        else
        {
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
    //������ ��������� ������� ����� � ����� ������� 5 ������ ����� ������
    private Vector2 SetRandomTargetPoint()
    {
        return (Random.insideUnitCircle * 5) + spawnPosition;
    }

    //��� ������������ �� ������ ������� ����� ������� �����. ������������ ������ Stay, �.�. ��� Enter ��� ��� ����� ��������
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            targetPoint = SetRandomTargetPoint();
        }
    }

    //��� ������������ � ������� �������� ��� ����� ��������� �����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionWith = collision.gameObject;
        if (collisionWith.tag == "Player")
        {
            collisionWith.GetComponent<Player>().GetDamage(attack);
        }
    }
}

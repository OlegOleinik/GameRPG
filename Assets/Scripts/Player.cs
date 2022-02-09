using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _maxHP;
    [SerializeField] private float damageCooldown;
    [SerializeField] private float defence;
    [SerializeField] private float attack;
    [SerializeField] private float blockChance;
    [SerializeField] private float dodgeChance;
    [SerializeField] private int money;
    [SerializeField] private int specsPoints;

    private float nextHitTime = 0;
    private float _requiredExperience=10;
    private float _experience=0;
    private int _currentHP;

    public int maxHP
    {
        get
        {
            return _maxHP;
        }
    }
    public int currentHP
    {
        get
        {
            return _currentHP;
        }
    }
    public float experience
    {
        get
        {
            return _experience;
        }
    }
    public float moveSpeed{
        get
        {
            return _moveSpeed;
        }
        set
        {
            _moveSpeed = value;
        }
    }
    public float requiredExperience
    {
        get
        {
            return _requiredExperience;
        }
    }
    //Устанавливает текущее ХП максимальным
    private void Start()
    {
        _currentHP = _maxHP;
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }
    //Добавление опыта, если выше требуемого-устанавливает требуемый больше, сбрасывает текущий, добавляет остаток
    public void AddExperience(float additionalExperience)
    {
        _experience += additionalExperience;
        if (_experience>=_requiredExperience)
        {
            _experience -= _requiredExperience;
            _requiredExperience *= 1.5f;
        }
    }
    //Получение урона игроком
    public void GetDamage(float damage)
    {
        if (nextHitTime<Time.time)
        {
            _currentHP -= System.Convert.ToInt32(damage);
            nextHitTime = Time.time + damageCooldown;
        }

    }
    private void FixedUpdate()
    {
        rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed);
    }
}

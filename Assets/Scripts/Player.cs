using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float _moveSpeed=0.06f;
    [SerializeField] private int _maxHP=5;
    [SerializeField] private float damageCooldown=1;
    [SerializeField] private float defence=1;
    [SerializeField] private float attack=1;
    [SerializeField] private float blockChance=1;
    [SerializeField] private float dodgeChance=1;
    [SerializeField] private float magicDamage=1;
    [SerializeField] private float magicRegen=1;
    [SerializeField] private float maxMagic=1;
    [SerializeField] private int money=1;
    [SerializeField] private int specsPoints=0;

    private float nextHitTime = 0;
    private float _requiredExperience=10;
    private float _experience=0;
    private int _currentHP;

    public float[] specsArray;
    //Dictionary<string, float> specsArray;

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

        //specsArray = new Dictionary<string, float>() { { "moveSpeed", _moveSpeed }, { "maxHP", _maxHP }, { "damageCooldown", damageCooldown }, { "defence", defence }, { "attack", attack },
        //{ "blockChance", blockChance },{ "dodgeChance", dodgeChance },{ "magicDamage", magicDamage },{ "magicRegen", magicRegen },{ "maxMagic", maxMagic }};

        specsArray = new float[] { _moveSpeed, _maxHP, damageCooldown, defence, attack, blockChance, dodgeChance, magicDamage, magicRegen, maxMagic};

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
            specsPoints++;
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

    public void IncreaseSpec(int id, float up)
    {
        if (specsPoints>0)
        {
            specsPoints--;
            specsArray[id] += up;
        }
    }
    private void FixedUpdate()
    {
        rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed);
    }
}

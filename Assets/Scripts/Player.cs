using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public float Value;


    public static implicit operator Stat(float value)
    {
        return new Stat
        {
            Value = value
        };
    }
    public static implicit operator float(Stat stat)
    {
        return stat.Value;
    }



    public override string ToString()
    {
        return Value.ToString();
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Stat _moveSpeed=0.06f;
    [SerializeField] private int _maxHP=5;
    [SerializeField] private float attackCooldown=1;
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
        Stat a = 13;
        Debug.Log(a);
        //specsArray = new Dictionary<string, float>() { { "moveSpeed", _moveSpeed }, { "maxHP", _maxHP }, { "damageCooldown", damageCooldown }, { "defence", defence }, { "attack", attack },
        //{ "blockChance", blockChance },{ "dodgeChance", dodgeChance },{ "magicDamage", magicDamage },{ "magicRegen", magicRegen },{ "maxMagic", maxMagic }};

        //specsArray = new Stat[] { _moveSpeed, _maxHP, attackCooldown, defence, attack, blockChance, dodgeChance, magicDamage, magicRegen, maxMagic};

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
            nextHitTime = Time.time + attackCooldown;
        }

    }

    public void IncreaseSpec(int id, float up)
    {
        //if (specsPoints>0)
        //{
         var specsArray = new Stat[] { _moveSpeed, _maxHP, attackCooldown, defence, attack, blockChance, dodgeChance, magicDamage, magicRegen, maxMagic };

        specsPoints--;
        assign(ref specsArray[id].Value, up);
            //specsArray[id].Value +=up;
        Debug.Log(_moveSpeed +"   "+ moveSpeed);
        //}
    }

    private void assign(ref float i, float up)
    {
        i += up;
    }
    private void FixedUpdate()
    {
        rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    //public override string ToString()
    //{
    //    return Value.ToString();
    //}
    //public override int GetHashCode()
    //{
    //    return Value.GetHashCode();
    //}
}

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float _moveSpeed=0.06f;
    [SerializeField] private Stat _maxStamina = 10;
    [SerializeField] private Stat _maxHP =5;
    [SerializeField] private Stat attackCooldown =1;
    [SerializeField] private Stat defence =1;
    [SerializeField] private Stat attack =1;
    [SerializeField] private Stat blockChance =1;
    [SerializeField] private Stat dodgeChance =1;
    [SerializeField] private Stat magicDamage =1;
    [SerializeField] private Stat magicRegen =1;
    [SerializeField] private Stat maxMagic =1;
    [SerializeField] private int money=0;
    [SerializeField] private int specsPoints=0;

    private float nextHitTime = 0;
    private float nextRegenStaminaTime = 0;
    private float _requiredExperience=10;
    private float _experience=0;
    private float _currentHP;
    private float _currentStamina;

    private bool isRegeneratedStamina = false;

    //Dictionary<string, float> specsArray;
    public float maxStamina
    {
        get
        {
            return _maxStamina;
        }
    }
    public float currentStamina
    {
        get
        {
            return _currentStamina;
        }
    }
    public float maxHP
    {
        get
        {
            return _maxHP;
        }
    }
    public float currentHP
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

        //specsArray = new Stat[] { _moveSpeed, _maxHP, attackCooldown, defence, attack, blockChance, dodgeChance, magicDamage, magicRegen, maxMagic};
        _currentStamina = _maxStamina;
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
        if (specsPoints > 0)
        {
            var specsArray = new Stat[] { _maxStamina, _maxHP, attackCooldown, defence, attack, blockChance, dodgeChance, magicDamage, magicRegen, maxMagic };

            specsPoints--;
            specsArray[id].Value += up;
            //Если ХП, то считает процентное соотношение шкалы до повышения и приравнивает новую к такому же отношению
            if (id == 1)
            {
                _currentHP = System.Convert.ToInt32((_currentHP / (_maxHP - up)) * maxHP);
            }
        }
    }

    //private void assign(ref float i, float up)
    //{
    //    i += up;
    //}
    private void FixedUpdate()
    {

        Move();
    }
    //Движение. Ускорение, если нажат Shift и выносливасть > 0. Если Shift не нажата, то запускается регенерация выносливости через полторы секунды
    private void Move()
    {
        if (Input.GetButton("Shift") && _currentStamina>0)
        {
            rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed * 2);
            _currentStamina -= 0.1f;
            isRegeneratedStamina = false;
            nextRegenStaminaTime = Time.time + 1.5f;
        }
        else
        {
            rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed);
            if (!isRegeneratedStamina && nextRegenStaminaTime<Time.time)
            {
                isRegeneratedStamina = true;
                StartCoroutine(RegenerateStamina());
            }
        }
    }
    //Регенерация выносливости
    IEnumerator RegenerateStamina()
    {
        while (_currentStamina<_maxStamina && isRegeneratedStamina)
        {
            _currentStamina += _maxStamina * 0.2f * Time.deltaTime;
            yield return null;
        }
        isRegeneratedStamina = false;
    }
}


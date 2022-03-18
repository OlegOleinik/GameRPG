using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public float Value;
    public float maxValue;

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
}

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Stat _maxStamina;
    [SerializeField] private Stat _maxHP;
    [SerializeField] private Stat _attackCooldown;
    [SerializeField] private Stat defence;
    [SerializeField] private Stat _attack;
    [SerializeField] private Stat blockChance;
    [SerializeField] private Stat dodgeChance;
    [SerializeField] private Stat _magicDamage;
    [SerializeField] private Stat magicRegen;
    [SerializeField] private Stat maxMagic;
    [SerializeField] private Stat _speech;
    [SerializeField] private int _money = 10;
    [SerializeField] private int _specsPoints = 0;




    private float nextHitTime = 0;
    private float nextRegenStaminaTime = 0;
    private float _requiredExperience=10;
    private float _experience=0;
    private float _currentHP;
    private float _currentStamina;

    private bool isRegeneratedStamina = false;

    private PlayerAnimator playerAnimator;

    public float speech
    {
        get
        {
            return _speech;
        }
    }
    public float attackCooldown
    {
        get
        {
            return _attackCooldown;
        }
    }
//Dictionary<string, float> specsArray;
    public float attack
    {
        get
        {
            return _attack;
        }
    }
    public float magicDamage
    {
        get
        {
            return _magicDamage;
        }
    }
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
    public int money
    {
        set
        {
            _money = value;
        }
        get
        {
            return _money;
        }
    }
    public int specsPoints
    {
        get
        {
            return _specsPoints;
        }
    }


    //Устанавливает текущее ХП максимальным
    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        _currentStamina = _maxStamina;
        _currentHP = _maxHP;
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }

    public void RecoverHP(int addHP)
    {
        _currentHP += addHP;
        if (_currentHP > maxHP)
        {
            _currentHP = maxHP;
        }
    }
    //Добавление опыта, если выше требуемого-устанавливает требуемый больше, сбрасывает текущий, добавляет остаток
    public void AddExperience(float additionalExperience)
    {
        _experience += additionalExperience;
        if (_experience>=_requiredExperience)
        {
            _experience -= _requiredExperience;
            _requiredExperience *= 1.5f;
            _specsPoints++;
        }
    }
    //Получение урона игроком
    public void GetDamage(float damage)
    {
        if (nextHitTime<Time.time)
        {
            if (Random.Range(0f, 1f) > blockChance)
            {
                _currentHP -= damage - Mathf.Floor(damage * ((defence - 1) * 0.1f));
            }
            nextHitTime = Time.time + 0.5f;
        }

    }

    public Stat[] GetStats()
    {
        return new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, dodgeChance, _magicDamage, magicRegen, maxMagic, _speech };
    }

    public void IncreaseSpec(int id, float up)
    {
        if (_specsPoints > 0)
        {
            var specsArray = new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, dodgeChance, _magicDamage, magicRegen, maxMagic, _speech };
            
            if(specsArray[id]<specsArray[id].maxValue)
            {
                _specsPoints--;
                specsArray[id].Value += up;
                //Если ХП, то считает процентное соотношение шкалы до повышения и приравнивает новую к такому же отношению
                if (id == 1)
                {
                    _currentHP = System.Convert.ToInt32((_currentHP / (_maxHP - up)) * maxHP);
                }
            }
        }
    }
    private void FixedUpdate()
    {

        Move();
    }
    //Движение. Ускорение, если нажат Shift и выносливасть > 0. Если Shift не нажата, то запускается регенерация выносливости через полторы секунды
    private void Move()
    {
        if (Input.GetButton(("Horizontal")) || Input.GetButton(("Vertical")))
        {
            if (Input.GetButton("Shift") && _currentStamina > 0)
            {
                rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed * 2);
                _currentStamina -= 0.1f;
                isRegeneratedStamina = false;
                nextRegenStaminaTime = Time.time + 1.5f;
                playerAnimator.SetAnimation(2);
                playerAnimator.SetFlip(rb.position.x);
                return;
            }
            else
            {
                rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _moveSpeed);
                playerAnimator.SetFlip(rb.position.x);
                playerAnimator.SetAnimation(1);
                //ВЫНЕСТИ В МЕТОД
                if (!isRegeneratedStamina && nextRegenStaminaTime < Time.time)
                {
                    isRegeneratedStamina = true;
                    StartCoroutine(RegenerateStamina());
                    return;
                }
            }
        }
        else
        {
            playerAnimator.SetAnimation(0);
            //ВЫНЕСТИ В МЕТОД
            if (!isRegeneratedStamina && nextRegenStaminaTime < Time.time)
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

public class Player : MonoBehaviour, IMoveable, IDamagable, IDieable
{
    private Vector2 moveDir;
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
    [SerializeField] private Stat _maxMagic;
    [SerializeField] private Stat _speech;
    [SerializeField] private int _money = 10;
    [SerializeField] private int _specsPoints = 0;


    private float shiftMod = 1;

    private float nextHitTime = 0;
    private float nextRegenStaminaTime = 0;
    private float nextRegenMagicTime = 0;
    private float _requiredExperience=10;
    private float _experience=0;
    private float _currentHP;
    private float _currentStamina;
    private float _currentMagic;

    private bool isRegeneratedStamina = false;
    private bool isRegeneratedMagic = false;
    private bool isWasteStamina = false;

    [SerializeField] private PlayerAnimator playerAnimator;


    public float maxMagic
    {
        get
        {
            return _maxMagic;
        }
    }
    public float currentMagic
    {
        get
        {
            return _currentMagic;
        }
        set
        {
            _currentMagic = value;
        }
    }
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
        //playerAnimator = GetComponent<PlayerAnimator>();
        _currentStamina = _maxStamina;
        _currentHP = _maxHP;
        _currentMagic = _maxMagic;
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
    public void GetDamage(float damage, Vector2 force)
    {
        if (nextHitTime<Time.time)
        {
            if (Random.Range(0f, 1f) > blockChance)
            {
                LostHP(damage);
                GetForce(force);
            }
            nextHitTime = Time.time + 0.5f;
        }
    }

    public void GetDamage(float damage)
    {
        if (nextHitTime < Time.time)
        {
            if (Random.Range(0f, 1f) > blockChance)
            {
                LostHP(damage);
            }
        }
    }

    public void LostHP(float damage)
    {
        _currentHP -= damage - Mathf.Floor(damage * ((defence - 1) * 0.1f));
        playerAnimator.Hit();
        StartCoroutine(Wait());
    }

    public void GetForce(Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }



    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimator.HeadIdle();
    }

    public Stat[] GetStats()
    {
        return new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, dodgeChance, _magicDamage, magicRegen, _maxMagic, _speech };
    }

    public void IncreaseSpec(int id, float up)
    {
        if (_specsPoints > 0)
        {
            var specsArray = new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, dodgeChance, _magicDamage, magicRegen, _maxMagic, _speech };
            
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
        if (!isRegeneratedStamina && nextRegenStaminaTime < Time.time)
        {
            isRegeneratedStamina = true;
            StartCoroutine(RegenerateStamina());
        }
        if (!isRegeneratedMagic && nextRegenMagicTime < Time.time)
        {
            StartCoroutine(RegenerateMagic());
        }
    }

    public void GetRun(InputAction.CallbackContext inputValue)
    {
        if (inputValue.phase == InputActionPhase.Started)
        {
            StartCoroutine(wasteStamina());
        }
        else if (inputValue.phase == InputActionPhase.Canceled)
        {
            shiftMod = 1;
            isWasteStamina = false;
        }
    }

    public void GetMove(InputAction.CallbackContext inputValue)
    {
        
        moveDir = inputValue.ReadValue<Vector2>();

        
        //playerAnimator.SetFlip(moveDir.x);
        playerAnimator.Walk();
        if (inputValue.phase == InputActionPhase.Started && !isWasteStamina)
        {
            //playerAnimator.SetAnimation(1);
            playerAnimator.Walk();
        }
        else if (inputValue.phase == InputActionPhase.Canceled)
        {
            //  playerAnimator.SetAnimation(0);
            playerAnimator.Idle();
        }
    }
    //Движение. Ускорение, если нажат Shift и выносливасть > 0. Если Shift не нажата, то запускается регенерация выносливости через полторы секунды
    public void Move()
    {
        rb.position += (moveDir * _moveSpeed * shiftMod);
        playerAnimator.FlipPlayer(moveDir.x);
    }
    //Регенерация выносливости
    private IEnumerator RegenerateStamina()
    {
        while (_currentStamina<_maxStamina && isRegeneratedStamina)
        {
            _currentStamina += _maxStamina * 0.2f * Time.deltaTime;
            yield return null;
        }
        isRegeneratedStamina = false;
    }

    public void WasteMagic(float waste)
    {
        _currentMagic -= waste;
        nextRegenMagicTime = Time.time + 1.5f;
        isRegeneratedMagic = false;
    }

    private IEnumerator RegenerateMagic()
    {
        isRegeneratedMagic = true;
        while (_currentMagic < _maxMagic && isRegeneratedMagic)
        {
            _currentMagic += _maxMagic * magicRegen * Time.deltaTime;
            yield return null;
        }
        isRegeneratedMagic = false;
    }

    private IEnumerator wasteStamina()
    {
        isWasteStamina = true;
        shiftMod = 2;
        while (isWasteStamina)
        {
            if (_currentStamina > 0 && moveDir != Vector2.zero)
            {
                isRegeneratedStamina = false;
                shiftMod = 2;
                _currentStamina -= 5f * Time.deltaTime;
                nextRegenStaminaTime = Time.time + 1.5f;
                // playerAnimator.SetAnimation(2);
                playerAnimator.Run();
                yield return null;
            }
            else if (moveDir != Vector2.zero)
            {
                // playerAnimator.SetAnimation(1);
                playerAnimator.Walk();
            }
            shiftMod = 1;
            yield return null;
        }
        if (moveDir != Vector2.zero)
        {
            //  playerAnimator.SetAnimation(1);
            playerAnimator.Walk();
        }
        shiftMod = 1;
    }

    public void Die()
    {
        //throw new System.NotImplementedException();
    }


}


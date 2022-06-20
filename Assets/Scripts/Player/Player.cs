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
    [SerializeField] private Stat _repulsion;
    [SerializeField] private Stat _magicDamage;
    [SerializeField] private Stat magicRegen;
    [SerializeField] private Stat _maxMagic;
    [SerializeField] private Stat _speech;
    [SerializeField] private int _money = 10;
    [SerializeField] private int _specsPoints = 0;
    public Transform spellCastPoint;
    private float shiftMod = 1;
    private float nextHitTime = 0;
    private float nextRegenStaminaTime = 0;
    private float nextRegenMagicTime = 0;
    private float _requiredExperience = 10;
    private float _experience = 0;
    private float _currentHP;
    private float _currentStamina;
    private float _currentMagic;
    private float _rollCollDown = 0;
    private bool isRegeneratedStamina = false;
    private bool isRegeneratedMagic = false;
    private bool isWasteStamina = false;
    private int _lvl = 0;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private PlayerAudio playerAudio;
    private float targetYCamOffset;

    private const float NEXTLVLEXPMOD = 1.5f;
    private const float NEXTHITCD = 0.5f;
    private const float ROLLCD = 1f;
    private const float ROLLFORCEMOD = 50;
    private const float ROLLSTAMINACOST = 3f;
    private const float STAMINAREGENCD = 1.5f;
    private const float STAMINARUNWASTE = 5f;
    private const float MAGICREGEN = 1.5f;
    private const float STAMINAREGEN = 0.2f;

    public float rollCollDown
    {
        get
        {
            return _rollCollDown;
        }
        set
        {
            _rollCollDown = value;
        }
    }
    public int lvl
    {
        get
        {
            return _lvl;
        }
        set
        {
            _lvl = value;
        }
    }
    public float maxMagic
    {
        get
        {
            return _maxMagic;
        }
        set
        {
            _maxMagic = value;
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
    public float repulsion
    {
        get
        {
            return _repulsion;
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
        set
        {
            _currentStamina = value;
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
        set
        {
            _currentHP = value;
        }
    }
    public float experience
    {
        get
        {
            return _experience;
        }
        set
        {
            _experience = value;
        }
    }
    public float moveSpeed {
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
        set
        {
            _requiredExperience = value;
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
        set
        {
            _specsPoints = value;
        }
    }

    //Устанавливает текущее ХП максимальным
    private void Start()
    {
        _currentStamina = _maxStamina;
        _currentHP = _maxHP;
        _currentMagic = _maxMagic;
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip audioClip)
    {
        playerAudio.PlaySound(audioClip);
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
        if (_experience >= _requiredExperience)
        {
            _experience -= _requiredExperience;
            _requiredExperience *= NEXTLVLEXPMOD;
            _specsPoints++;
            _lvl++;
        }
    }
    //Получение урона игроком
    public void GetDamage(float damage, Vector2 force)
    {
        if (nextHitTime < Time.time)
        {
            if (Random.Range(0f, 1f) > blockChance)
            {
                LostHP(damage);
                GetForce(force);
            }
            nextHitTime = Time.time + NEXTHITCD;
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
            nextHitTime = Time.time + NEXTHITCD;
        }
    }

    public void LostHP(float damage)
    {
        _currentHP -= damage - Mathf.Floor(damage * ((defence - 1) * 0.1f));
        if (_currentHP <= 0)
        {
            Die();
            return;
        }
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
        return new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, _repulsion, _magicDamage, magicRegen, _maxMagic, _speech };
    }
    public void SetStats(List<float> loadedStats)
    {
        var stats = new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, _repulsion, _magicDamage, magicRegen, _maxMagic, _speech };
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i].Value = loadedStats[i];
        }
    }

    public void SetDefaultStats()
    {
        _maxStamina.Value = 10;
        _maxHP.Value = 5;
        _attackCooldown.Value = 0.1f;
        defence.Value = 1;
        _attack.Value = 1;
        blockChance.Value = 0;
        _repulsion.Value = 2.5f;
        _magicDamage.Value = 1;
        magicRegen.Value = 0.1f;
        _maxMagic.Value = 10;
        _speech.Value = 1;
    }
    public void IncreaseSpec(int id, float up)
    {
        if (_specsPoints > 0)
        {
            var specsArray = new Stat[] { _maxStamina, _maxHP, _attackCooldown, defence, _attack, blockChance, _repulsion, _magicDamage, magicRegen, _maxMagic, _speech };
            
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

    public void Roll(InputAction.CallbackContext inputValue)
    {
        if (inputValue.phase == InputActionPhase.Started && _rollCollDown < Time.time && _currentStamina >= 3)
        {
            _rollCollDown = Time.time + ROLLCD;
            rb.AddForce(moveDir*ROLLFORCEMOD, ForceMode2D.Impulse);
            _currentStamina -= ROLLSTAMINACOST;
            isRegeneratedStamina = false;
            nextRegenStaminaTime = Time.time + STAMINAREGENCD;
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
        playerAnimator.Walk();
        if (inputValue.phase == InputActionPhase.Started && !isWasteStamina)
        {
            playerAnimator.Walk();
            playerAudio.PlayerWalk();
        }
        else if (inputValue.phase == InputActionPhase.Canceled)
        {
            playerAnimator.Idle();
            playerAudio.PlayerStop();
        }
    }

    //Движение. Ускорение, если нажат Shift и выносливасть > 0. Если Shift не нажата, то запускается регенерация выносливости через полторы секунды
    public void Move()
    {
        rb.position += (moveDir * _moveSpeed * shiftMod);
        playerAnimator.FlipPlayer(moveDir.x);
        float xOffset = 0;
        float yOffset = 0;
        if (Camera.main.transform.localPosition.x < 1)
        {
            xOffset = 0.05f;
        }
        if (moveDir.y != 0)
        {
            targetYCamOffset = moveDir.y/Mathf.Abs(moveDir.y);
        }
        if ( Mathf.Abs(Camera.main.transform.localPosition.y - targetYCamOffset) > 0.2f)
        {
            yOffset = targetYCamOffset * 0.05f;
        }
        Camera.main.transform.localPosition += new Vector3(xOffset, yOffset, 0);
    }

    //Регенерация выносливости
    private IEnumerator RegenerateStamina()
    {
        while (_currentStamina<_maxStamina && isRegeneratedStamina)
        {
            _currentStamina += _maxStamina * STAMINAREGEN * Time.deltaTime;
            yield return null;
        }
        isRegeneratedStamina = false;
    }

    public void WasteMagic(float waste)
    {
        _currentMagic -= waste;
        nextRegenMagicTime = Time.time + MAGICREGEN;
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
                _currentStamina -= STAMINARUNWASTE * Time.deltaTime;
                nextRegenStaminaTime = Time.time + STAMINAREGENCD;
                playerAnimator.Run();
                playerAudio.PlayerRun();
                yield return null;
            }
            else if (moveDir != Vector2.zero)
            {
                playerAnimator.Walk();
                playerAudio.PlayerWalk();
            }
            shiftMod = 1;
            yield return null;
        }
        if (moveDir != Vector2.zero)
        {
            playerAnimator.Walk();
            playerAudio.PlayerWalk();
        }
        shiftMod = 1;
    }

    public void Die()
    { 
        GameManager.UI.GetComponent<UIScript>().SetDeathMessage(GetEnemy(), _money, _lvl, GetComponent<AttackController>().GetSword().itemName);
        GetComponent<PlayerInput>().enabled = false;
    }

    //Не самое лучшее решение. Передавать источник последнего урона в переменную было бы лучше
    public string GetEnemy()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 origin = transform.position;
        float[] distances = new float[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            distances[i] = (objects[i].transform.position - origin).sqrMagnitude;
        }
        System.Array.Sort(distances, objects);
        return objects[0].GetComponent<AEnemy>().enemyName;
    }
}


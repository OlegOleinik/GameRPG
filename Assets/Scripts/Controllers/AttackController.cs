using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sword sword;
    private MagicCellsPanel MagicCellsPanel;
    private float coolDownTime;

    void Start()
    {
        sword.gameObject.SetActive(false);
        MagicCellsPanel = GameObject.Find("MagicCells").GetComponent<MagicCellsPanel>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && EnableToAttck() && GameManager.isGamePaused == false)
        {
            sword.gameObject.SetActive(true);
            SetCoolDown(sword.Strike1());
        }
        else if (Input.GetButtonDown("Fire2") && EnableToAttck() && GameManager.isGamePaused == false)
        {
            SetCoolDown(MagicCellsPanel.CastSpell());
        }


    }
    //¬озвращает TRUE, если возможна атака и прошло достаточно времени с предыдущей
    public bool EnableToAttck()
    {
        return (sword.ableToAttack && coolDownTime < Time.time);
    }

    private void SetCoolDown(float addTime)
    {
        coolDownTime = Time.time + addTime;
    }
}

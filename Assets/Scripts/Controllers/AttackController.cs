using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sword sword;
    private MagicCellsPanel MagicCellsPanel;
    private float coolDownTime;
    private Player player;

    void Start()
    {
        //sword.gameObject.SetActive(false);
        MagicCellsPanel = GameObject.Find("MagicCells").GetComponent<MagicCellsPanel>();
        player = GameManager.player.GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && EnableToAttck() && GameManager.isGamePaused == false)
        {
            sword.gameObject.SetActive(true);
            SetCoolDown(sword.Strike1()*(0.1f/player.attackCooldown));
        }
        else if (Input.GetButtonDown("Fire2") && EnableToAttck() && GameManager.isGamePaused == false)
        {
            SetCoolDown(MagicCellsPanel.CastSpell());
        }


    }
    //���������� TRUE, ���� �������� ����� � ������ ���������� ������� � ����������
    public bool EnableToAttck()
    {
        return (sword.ableToAttack && coolDownTime < Time.time);
    }

    private void SetCoolDown(float addTime)
    {
        coolDownTime = Time.time + addTime;
    }
}

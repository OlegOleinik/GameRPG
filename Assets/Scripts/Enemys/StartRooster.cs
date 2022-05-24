using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartRooster : Rooster
{
    int atcCount = 0;
    [SerializeField] private Image imageBlackout;
    private GameManager.EndCorutine end;
    [SerializeField] GameObject firstStep;

    public override void Start()
    {
        base.Start();
        end = LoseBattle;
        GameManager.player.GetComponent<QuestsController>().AddQuest(Instantiate(firstStep));
    }

    public override void GetDamage(float damage)
    {
        
    }

    public override void GetDamage(float damage, Vector2 force)
    {
        GetForce(force);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            atcCount++;
            if (atcCount == 3)
            {
                StartCoroutine(2f.Tweeng((u) => imageBlackout.color = new Color(0, 0, 0, u), 0, 1, end));
            }
        }
    }


    private void LoseBattle()
    {
        GameManager.player.GetComponent<Player>().GetDamage(1);
        GameManager.player.GetComponent<QuestsController>().onDefeatStartRooster?.Invoke();
        SceneManager.LoadScene("0.0");
        GameManager.player.transform.position = new Vector2(-9, -3.8f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportSpell : ASpell
{
    private GameManager.EndCorutine end;
    public override void Spell()
    {
        HidePlayer();
        Vector2 startHere = GameManager.player.transform.position;
        Vector2 endHere = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        StartCoroutine(1f.Tweeng((p) => GameManager.player.transform.position = p, startHere, endHere, end));
    }

    public override void Start()
    {
        end = ShowPlayer;
        DontDestroyOnLoad(gameObject);
        transform.SetParent(GameManager.player.transform);
    }
    private void ShowPlayer()
    {
        GameManager.player.GetComponent<BoxCollider2D>().enabled = true;
        GameManager.player.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void HidePlayer()
    {
        GameManager.player.GetComponent<BoxCollider2D>().enabled = false;
        GameManager.player.GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void SetLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }
}

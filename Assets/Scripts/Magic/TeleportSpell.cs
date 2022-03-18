using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpell : ASpell
{
    private GameManager.EndCorutine end;
    public override void Spell()
    {
        Vector2 startHere = GameManager.player.transform.position;
        Vector2 endHere = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(2f.Tweeng((p) => transform.position = p,
  startHere,
  endHere, end));
    }

    public override void Start()
    {
        DontDestroyOnLoad(gameObject);
        transform.SetParent(GameManager.player.transform);
    }
    private void ShowPlayer()
    {

    }


}

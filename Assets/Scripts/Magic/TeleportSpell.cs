using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportSpell : ASpell
{
    [SerializeField] GameObject circle;
    private float maxDistance;
    [SerializeField] GameObject teleporter;

    public override bool Spell()
    {
        Vector2 startHere = GameManager.player.transform.position;
        Vector2 endHere = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(startHere, (endHere - startHere).normalized, Vector2.Distance(startHere, endHere), LayerMask.GetMask("Wall"));
        if (Vector2.Distance(startHere, endHere) < maxDistance && hit.collider == null)
        {
            GameObject newTeleporter = Instantiate(teleporter, GameManager.player.transform);
            newTeleporter.GetComponent<Teleporter>().TeleportPlayer(startHere, endHere);
            return true;
        }
        return false;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void SetLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                maxDistance = 2.5f;
                break;
            case 2:
                maxDistance = 3;
                break;
            case 3:
                maxDistance = 3.5f;
                break;
            case 4:
                maxDistance = 4;
                break;
            case 5:
                maxDistance = 5;
                break;
            default:
                break;
        }
        circle = Instantiate(circle, GameManager.player.transform);
        circle.GetComponent<SpriteRenderer>().material.SetFloat("_Scale", 0.063f * maxDistance);
    }

    private void OnDestroy()
    {
        Destroy(circle);
    }
}

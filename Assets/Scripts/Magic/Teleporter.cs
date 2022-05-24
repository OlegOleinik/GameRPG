using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private void ShowPlayer()
    {
        GameManager.player.GetComponent<PlayerAnimator>().HidePlayer(false);
        Destroy(gameObject);
    }

    private void HidePlayer()
    {
        GameManager.player.GetComponent<PlayerAnimator>().HidePlayer(true);
    }

    public void TeleportPlayer(Vector2 startHere, Vector2 endHere)
    {
        HidePlayer();
        GameManager.EndCorutine end;
        end = ShowPlayer;
        StartCoroutine(1f.Tweeng((p) => GameManager.player.transform.position = p, startHere, endHere, end));
    }
}

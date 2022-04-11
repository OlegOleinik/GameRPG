using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaminaBar : ABar
{
    private Player player;

    public override float UpdateCount()
    {
        return player.currentStamina / player.maxStamina;
    }
    public override void SetLocalParams()
    {
        player = GameManager.player.GetComponent<Player>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicBar : ABar
{

    private Player player;

    public override void SetLocalParams()
    {
        player = GameManager.player.GetComponent<Player>();

    }

    public override float UpdateCount()
    {
        return player.currentMagic / player.maxMagic;
    }
}

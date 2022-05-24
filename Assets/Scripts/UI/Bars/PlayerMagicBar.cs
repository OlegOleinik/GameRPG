using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicBar : ABar
{
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    private Player player;

    public override void SetLocalParams()
    {
        player = GameManager.player.GetComponent<Player>();
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }

    public override float UpdateCount()
    {
        return player.currentMagic / player.maxMagic;
    }
}

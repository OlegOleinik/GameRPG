using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : ABar
{
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
        return player.currentHP / player.maxHP;
    }
<<<<<<< Updated upstream


=======
>>>>>>> Stashed changes
}

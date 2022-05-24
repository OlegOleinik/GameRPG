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
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    public override float UpdateCount()
    {
        return player.currentHP / player.maxHP;
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream


=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
}

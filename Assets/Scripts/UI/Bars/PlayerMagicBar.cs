using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicBar : ABar
{
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    private Player player;

    public override void SetLocalParams()
    {
        player = GameManager.player.GetComponent<Player>();
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    public override float UpdateCount()
    {
        return player.currentMagic / player.maxMagic;
    }
}
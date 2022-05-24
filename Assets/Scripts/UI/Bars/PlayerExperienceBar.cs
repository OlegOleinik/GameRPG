using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperienceBar : ABar
{
    private Player player;

    public override void SetLocalParams()
    {
        player = GameManager.player.GetComponent<Player>();
    }

    public override float UpdateCount()
    {
        return player.experience / player.requiredExperience;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpResource : Resource
{
    public HeroKnight player;
    public float duration = 10f;

    public override bool ActivateResource()
    {
        player.DoubleJump(duration);
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremeMassResource : Resource
{
    public HeroKnight player;
    public float duration = 60f;

    public override bool ActivateResource()
    {
        player.ExtremeMass(duration);
        return true;
    }
}

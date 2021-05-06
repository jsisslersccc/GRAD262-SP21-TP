using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyResource : Resource
{
    public HeroKnight player;

    public override bool ActivateResource()
    {
        SceneGateway Gateway = FindSceneGatewayClosestToPlayer();
        if (Gateway)
        {
            Gateway.Unlock();
            return true;
        }
        else
        {
            return false;
        }
    }
}

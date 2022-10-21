using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackPlayer : Actions
{
    public override void DoAction()
    {
        FightManager.hpEnemy.value = FightManager.hpEnemy.value - (2 + FightManager.buffStat); 
    }

    public override int GetPriority()
    {
        return 2;
    }

    public override string GetEntitie()
    {
        return "Player";
    }
}

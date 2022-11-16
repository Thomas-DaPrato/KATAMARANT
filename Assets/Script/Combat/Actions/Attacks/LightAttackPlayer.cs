using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackPlayer : Actions
{
    public override void DoAction()
    {
        FightManager1Vs1.hpEnemy.value = FightManager1Vs1.hpEnemy.value - (2 + FightManager1Vs1.buffStat); 
    }

    public override int GetPriority()
    {
        return 2;
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "LightAttack";
    }
}

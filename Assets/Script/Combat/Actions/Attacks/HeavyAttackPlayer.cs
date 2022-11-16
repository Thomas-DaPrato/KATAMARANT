using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HeavyAttackPlayer : Actions
{

    public override void DoAction()
    {
        FightManager1Vs1.hpEnemy.value = FightManager1Vs1.hpEnemy.value - (5 + FightManager1Vs1.buffStat);
    }

    public override int GetPriority()
    {
        return 10;
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "HeavyAttack";
    }
}

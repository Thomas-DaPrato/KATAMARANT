using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HeavyAttackPlayer : Actions
{

    public override void DoAction()
    {
        FightManager.hpEnemy.value = FightManager.hpEnemy.value - (5 + FightManager.buffStat);
    }

    public override int GetPriority()
    {
        return 10;
    }

    public override string GetEntitie()
    {
        return "Player";
    }
}

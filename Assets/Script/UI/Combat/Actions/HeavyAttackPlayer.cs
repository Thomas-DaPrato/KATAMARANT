using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HeavyAttackPlayer : Actions
{
    public static int priority = 10;
    public override void DoAction()
    {
        print("action joueur");
        FightManager.hpEnemy.value = FightManager.hpEnemy.value - 5;
    }

    public override int GetPriority()
    {
        return priority;
    }

    public override string GetEntitie()
    {
        return "Player";
    }
}

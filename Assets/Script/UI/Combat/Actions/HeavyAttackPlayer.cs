using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HeavyAttackPlayer : Actions
{
    public static int priority = 10;
    public override void DoAction()
    {
        CombatManager.hpEnemy.value = CombatManager.hpEnemy.value - 5;
    }

    public override int GetPriority()
    {
        return priority;
    }
}

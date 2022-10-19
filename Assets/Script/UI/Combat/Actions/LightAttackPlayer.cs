using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackPlayer : Actions
{
    public int priority = 2;
    public override void DoAction()
    {
        CombatManager.hpEnemy.value = CombatManager.hpEnemy.value - 2; 
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

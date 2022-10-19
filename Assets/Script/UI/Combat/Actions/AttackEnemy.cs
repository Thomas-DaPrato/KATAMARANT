using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Actions
{
    public int priority = 5;

    public override void DoAction()
    {
        print("action ennemi");
        CombatManager.hpPlayer.value = CombatManager.hpPlayer.value - 3;
    }

    public override int GetPriority()
    {
        return priority;
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }
}

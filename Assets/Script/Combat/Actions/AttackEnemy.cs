using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Actions
{

    public override void DoAction()
    {
        FightManager.hpPlayer.value = FightManager.hpPlayer.value - 3;
    }

    public override int GetPriority()
    {
        return 5;
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankNormalAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= 2;
    }

    public override string GetAnimation()
    {
        return "AttackEnemy";
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }

    public override int GetPriority()
    {
        return 5;
    }
}

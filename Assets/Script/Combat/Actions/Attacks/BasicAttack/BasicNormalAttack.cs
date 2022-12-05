using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNormalAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= (5 * FightManager.buffStatEnemy[FightManager.whichEnemyAttack]);
    }

    public override string GetAnimation()
    {
        return "BasicNormalAttack";
    }

    public override string GetEntitie()
    {
        return "Basic";
    }

}

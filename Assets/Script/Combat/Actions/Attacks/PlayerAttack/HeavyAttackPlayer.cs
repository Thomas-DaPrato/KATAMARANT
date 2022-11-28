using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HeavyAttackPlayer : Actions
{

    public override void DoAction()
    {
        FightManager.enemiesHP[FightManager.wichEnemyToFight].value -= (5 * FightManager.buffStatPlayer);
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

using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HeavyAttackPlayer : Actions
{

    public override void DoAction()
    {
        FightManager.enemiesHP[FightManager.whichEnemyToFight].value -= (5 * FightManager.buffStatPlayer);
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

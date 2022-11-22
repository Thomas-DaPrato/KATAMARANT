using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightAttackPlayer : Actions
{
    public override void DoAction()
    {
        foreach (Slider enemyHp in FightManager.enemiesHP)
            enemyHp.value = enemyHp.value - (2 * FightManager.buffStat);
    }

    public override int GetPriority()
    {
        return 2;
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "LightAttack";
    }
}

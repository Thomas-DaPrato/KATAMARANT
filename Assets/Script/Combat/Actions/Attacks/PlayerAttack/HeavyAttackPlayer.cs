using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using TMPro;

public class HeavyAttackPlayer : Actions
{

    public override void DoAction()
    {
        if (FightManager.enemies[FightManager.whichEnemyToFight].GetComponent<Enemies>().canTakeDamage)
            FightManager.enemiesHP[FightManager.whichEnemyToFight].value -= (4 * FightManager.buffStatPlayer);
        else
            GameObject.Find("ContentFightScene").GetComponent<FightManager>().StartCoroutineLever();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightAttackPlayer : Actions
{
    public override void DoAction()
    {
        if (FightManager.enemies[FightManager.whichEnemyToFight].GetComponent<Enemies>().canTakeDamage)
            foreach (Slider enemyHp in FightManager.enemiesHP)
                enemyHp.value -= (2 * FightManager.buffStatPlayer);
        else
            GameObject.Find("ContentFightScene").GetComponent<FightManager>().StartCoroutineLever();
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

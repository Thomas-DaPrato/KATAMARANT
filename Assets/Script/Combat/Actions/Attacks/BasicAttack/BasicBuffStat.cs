using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuffStat : Actions
{
    public override void DoAction()
    {
        FightManager.buffStatEnemy = 2;
        FightManager.enemiesDisplay[FightManager.whichEnemyAttack].transform.GetChild(1).GetComponent<ChangeStatus>().EnableStatus();
        FightManager.enemiesDisplay[FightManager.whichEnemyAttack].transform.GetChild(1).GetComponent<ChangeStatus>().ChangeStatusToBuff();
    }

    public override string GetAnimation()
    {
        return "BasicBuffAttack";
    }

    public override string GetEntitie()
    {
        return "Basic";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunt : Actions
{
    public override void DoAction()
    {
        FightManager.timeStunt = 2;
        FightManager.whichEnemyIsStunt = FightManager.whichEnemyToFight;
        FightManager.actions.RemoveAt(1);
        FightManager.enemiesDisplay[FightManager.whichEnemyToFight].transform.GetChild(1).GetComponent<ChangeStatus>().EnableStatus();
        FightManager.enemiesDisplay[FightManager.whichEnemyToFight].transform.GetChild(1).GetComponent<ChangeStatus>().ChangeStatusToStunt();
    }


    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "Stunt";
    }
}

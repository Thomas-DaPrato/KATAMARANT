using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuffStat : Actions
{
    public override void DoAction()
    {
        FightManager.buffStatEnemy = 2;
    }

    public override string GetAnimation()
    {
        return "BasicBuffAttack";
    }

    public override string GetEntitie()
    {
        return "Basic";
    }

    public override int GetPriority()
    {
        return 5;
    }
}

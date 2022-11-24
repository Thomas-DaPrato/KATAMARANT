using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNormalAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= 3;
    }

    public override string GetAnimation()
    {
        return "BasicNormalAttack";
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

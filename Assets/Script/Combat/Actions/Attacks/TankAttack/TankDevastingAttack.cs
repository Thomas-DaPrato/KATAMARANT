using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDevastingAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= 10;
    }

    public override string GetAnimation()
    {
        return "TankDevastingAttack";
    }

    public override string GetEntitie()
    {
        return "Tank";
    }

    public override int GetPriority()
    {
        return 10;
    }
}

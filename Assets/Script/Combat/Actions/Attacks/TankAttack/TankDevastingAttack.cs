using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDevastingAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= 8;
    }

    public override string GetAnimation()
    {
        return "TankDevastingAttack";
    }

    public override string GetEntitie()
    {
        return "Tank";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankNormalAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= 3;
    }

    public override string GetAnimation()
    {
        return "TankNormalAttack";
    }

    public override string GetEntitie()
    {
        return "Tank";
    }

}

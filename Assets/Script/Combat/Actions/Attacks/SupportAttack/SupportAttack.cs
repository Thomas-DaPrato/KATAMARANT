using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAttack : Actions
{
    public override void DoAction()
    {
        FightManager.playerHp.value -= 2;
    }

    public override string GetAnimation()
    {
        return "SupportNormalAttack";
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }

    public override int GetPriority()
    {
        return 3;
    }
}

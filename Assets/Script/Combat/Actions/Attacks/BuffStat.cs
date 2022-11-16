using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStat : Actions
{
    public override void DoAction()
    {
        FightManager1Vs1.buffStat = 5;
        FightManager1Vs1.buffStatTimer = 2; 
        
    }

    public override int GetPriority()
    {
        return 10;
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "buffAttack";
    }
}

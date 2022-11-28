using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStat : Actions
{
    public override void DoAction()
    {
        FightManager.buffStatPlayer = 2;
        FightManager.buffStatPlayerTimer = 3; 
        
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
        return "BuffAttack";
    }
}

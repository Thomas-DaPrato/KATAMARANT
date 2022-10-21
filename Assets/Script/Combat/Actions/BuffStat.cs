using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStat : Actions
{
    public override void DoAction()
    {
        FightManager.buffStat = 5;
        FightManager.buffStatTimer = 2; 
    }

    public override int GetPriority()
    {
        return 10;
    }

    public override string GetEntitie()
    {
        return "Player";
    }
}

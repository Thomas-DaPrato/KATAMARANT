using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntPlayer : Actions
{
    public override void DoAction()
    {
        FightManager.timeStunt = 2; 
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

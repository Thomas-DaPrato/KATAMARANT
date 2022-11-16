using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunt : Actions
{
    public override void DoAction()
    {
        FightManager1Vs1.timeStunt = 2; 
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
        return "Stunt";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popo : Actions
{
    public override void DoAction()
    {
        
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "popo";
    }
}

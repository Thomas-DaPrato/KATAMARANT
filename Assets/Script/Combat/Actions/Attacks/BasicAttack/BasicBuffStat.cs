using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuffStat : Actions
{
    public override void DoAction()
    {
        
    }

    public override string GetAnimation()
    {
        return "BasicBuffAttack";
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }

    public override int GetPriority()
    {
        return 5;
    }
}

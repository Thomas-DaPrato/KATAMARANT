using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAttack : Actions
{
    public override void DoAction()
    {
        
    }

    public override string GetAnimation()
    {
        return "AttackEnemy";
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }

    public override int GetPriority()
    {
        
    }
}

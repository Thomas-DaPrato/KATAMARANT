using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Actions
{

    public override void DoAction(){
        FightManager.playerHp.value -= 3;
    }

    public override int GetPriority(){
        return 5;
    }

    public override string GetEntitie(){
        return "Enemy";
    }

    public override string GetAnimation(){
        return "AttackEnemy";
    }
}

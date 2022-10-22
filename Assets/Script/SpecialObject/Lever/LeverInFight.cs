using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInFight : Actions
{
    public override void DoAction()
    {
        if(FightManager.typeOfEnemy == "lever"){
            FightManager.changeEnemySprite("Images/Enemies/Lever/levier_entier.png");
        }
        else
            Debug.Log("cela n'a aucun effet");
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override string GetEntitie()
    {
        return "Player";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInFight : Actions
{
    public Sprite sprite;

    public  LeverInFight(Sprite sp){
        sprite = sp;
    }
    public override void DoAction()
    {
        if(FightManager1Vs1.typeOfEnemy == "lever"){
            FightManager1Vs1.changeEnemySprite(sprite);
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

    public override string GetAnimation()
    {
        return "leverInFight";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverInFight : Actions
{
    public Sprite sprite;
    public GameObject enemyDisplay;


    public LeverInFight(Sprite sp, GameObject enemyDisplay){
        sprite = sp;
        this.enemyDisplay = enemyDisplay;
    }
    public override void DoAction()
    {
        if(FightManager.typeOfEnemy == "lever"){
            enemyDisplay.GetComponent<Image>().sprite = sprite;
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

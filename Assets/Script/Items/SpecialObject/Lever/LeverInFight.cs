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
        if(FightManager.typeOfEnemy == "Lever"){
            enemyDisplay.GetComponent<Image>().sprite = sprite;
            
        }
        else{
            Debug.Log("cela n'a aucun effet");
            
        }
            
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

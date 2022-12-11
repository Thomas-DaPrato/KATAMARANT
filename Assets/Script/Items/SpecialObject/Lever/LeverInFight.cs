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
        if (FightManager.typeOfEnemy == "Lever")
        {
            enemyDisplay.GetComponent<Image>().sprite = sprite;
            FightManager.enemies[FightManager.whichEnemyToFight].GetComponent<Enemies>().canTakeDamage = true;
            ButtonLeverInFight.DestroyGameObject();
        }
        else
            GameObject.Find("ContentFightScene").GetComponent<FightManager>().StartCoroutineItem();
            
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

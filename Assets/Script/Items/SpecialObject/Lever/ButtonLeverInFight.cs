using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLeverInFight : MonoBehaviour
{
    public Sprite sprite;
    public GameObject enemyDisplay;


    public void Start(){
        enemyDisplay = FightManager.enemiesDisplay[FightManager.whichEnemyToFight];
    }
    public void LeverInFight(){
        if(FightManager.endOfFightTuto && FightManager.canClickOnButton)
            FightManager.actions.Insert(0,new LeverInFight(sprite, enemyDisplay));
    }

    public static void DestroyGameObject(){
        Destroy(GameObject.Find("LeverInInventory"));
    }
}

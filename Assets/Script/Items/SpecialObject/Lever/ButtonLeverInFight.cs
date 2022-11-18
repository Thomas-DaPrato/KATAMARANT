using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLeverInFight : MonoBehaviour
{
    public Sprite sprite;
    public GameObject enemyDisplay;

    public void Start(){
        enemyDisplay = GameObject.Find("EnemyDisplay");
    }
    public void LeverInFight(){
        FightManager.actions.Add(new LeverInFight(sprite, enemyDisplay));
        Destroy(gameObject);
    }
}

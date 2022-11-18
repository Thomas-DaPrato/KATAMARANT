using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiceEnemy1 : MonoBehaviour
{

    public void ChoiceEnemy1(){
        FightManager.wichEnemyToFight = 0;
        FightManager.actions.Add(FightManager.actionPlayer);
        gameObject.transform.parent.gameObject.SetActive(false);
        FightManager.DoActionsEvent.Invoke();
    }
    
}

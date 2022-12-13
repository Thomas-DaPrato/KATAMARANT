using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiceEnemy1 : MonoBehaviour
{

    public void ChoiceEnemy1(){
        FightManager.whichEnemyToFight = 0;
        FightManager.actions.Insert(0,FightManager.actionPlayer);
        gameObject.transform.parent.gameObject.SetActive(false);
        FightManager.DoActionsEvent.Invoke();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiceEnemy3 : MonoBehaviour
{

    public void ChoiceEnemy3()
    {
        FightManager.whichEnemyToFight = 2;
        FightManager.actions.Insert(0,FightManager.actionPlayer);
        gameObject.transform.parent.gameObject.SetActive(false);
        FightManager.DoActionsEvent.Invoke();
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiceEnemy2 : MonoBehaviour
{

    public void ChoiceEnemy2()
    {
        FightManager.wichEnemyToFight = 1;
        FightManager.actions.Add(FightManager.actionPlayer);
        gameObject.transform.parent.gameObject.SetActive(false);
        FightManager.DoActionsEvent.Invoke();
    }

}

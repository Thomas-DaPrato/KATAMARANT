using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeavyAttack : MonoBehaviour
{

    public void HeavyAttack(){
        if (FightManager.endOfFightTuto && FightManager.canClickOnButton){
            FightManager.actionPlayer = new HeavyAttackPlayer();
            switch (FightManager.howManyEnemy){
                case FightManager.fight.oneEnemy:
                    FightManager.actions.Insert(0,new HeavyAttackPlayer());
                    print("actions size : " + FightManager.actions.Count);
                    FightManager.DoActionsEvent.Invoke();
                    break;
                case FightManager.fight.twoEnemies:
                    GameObject.Find("ContentFightScene").GetComponent<FightManager>().choiceEnemies.SetActive(true);
                    break;
                case FightManager.fight.threeEnemies :
                    GameObject.Find("ContentFightScene").GetComponent<FightManager>().choiceEnemies.SetActive(true);
                    break;

            }
 
        }
            
    }
}

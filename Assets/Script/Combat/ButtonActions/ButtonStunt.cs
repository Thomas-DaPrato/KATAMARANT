using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStunt : MonoBehaviour
{

   
    public void Stunt(){
        if (FightManager.endOfFightTuto && FightManager.canClickOnButton){
            FightManager.actionPlayer = new Stunt();
            switch (FightManager.howManyEnemy)
            {
                case FightManager.fight.oneEnemy:
                    FightManager.actions.Insert(0,new Stunt());
                    FightManager.DoActionsEvent.Invoke();
                    break;
                case FightManager.fight.twoEnemies:
                    GameObject.Find("ContentFightScene").GetComponent<FightManager>().choiceEnemies.SetActive(true);
                    break;
                case FightManager.fight.threeEnemies:
                    GameObject.Find("ContentFightScene").GetComponent<FightManager>().choiceEnemies.SetActive(true);
                    break;

            }

        }

    }
}

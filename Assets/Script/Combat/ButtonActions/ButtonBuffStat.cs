using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuffStat : MonoBehaviour
{
    public void BuffStat(){
        if(FightManager.endOfFightTuto && FightManager.canClickOnButton){
            FightManager.actions.Insert(0,new BuffStat());
            FightManager.DoActionsEvent.Invoke();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLightAttack : MonoBehaviour
{
    public void LightAttack(){
        if(FightManager.endOfFightTuto && FightManager.canClickOnButton){
            FightManager.actions.Add(new LightAttackPlayer());
            FightManager.DoActionsEvent.Invoke();
        }
            
    }
}

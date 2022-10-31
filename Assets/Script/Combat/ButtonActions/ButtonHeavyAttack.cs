using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeavyAttack : MonoBehaviour
{
    public void HeavyAttack(){
        if(FightManager.canClickOnButton){
            FightManager.actionsTurn.Add(new HeavyAttackPlayer());
        }
            
    }
}

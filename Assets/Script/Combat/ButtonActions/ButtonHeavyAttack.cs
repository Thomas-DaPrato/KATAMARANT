using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeavyAttack : MonoBehaviour
{
    public void HeavyAttack(){
        if(FightManager1Vs1.endOfFightTuto && FightManager1Vs1.canClickOnButton){
            FightManager1Vs1.actionsTurn.Add(new HeavyAttackPlayer());
        }
            
    }
}

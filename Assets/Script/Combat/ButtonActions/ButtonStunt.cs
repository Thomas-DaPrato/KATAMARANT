using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStunt : MonoBehaviour
{
    public void Stunt(){
        if(FightManager.endOfFightTuto && FightManager.canClickOnButton){
            FightManager.actionsTurn.Add(new StuntPlayer());
        }
            
    }
}

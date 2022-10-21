using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLightAttack : MonoBehaviour
{
    public void LightAttack(){
        FightManager.actionsTurn.Add(new LightAttackPlayer());
    }
}

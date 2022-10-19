using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeavyAttack : MonoBehaviour
{
    public void HeavyAttack(){
        CombatManager.actionsTurn.Add(new HeavyAttackPlayer());
    }
}

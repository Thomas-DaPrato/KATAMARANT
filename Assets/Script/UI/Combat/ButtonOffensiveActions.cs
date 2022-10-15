using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOffensiveActions : MonoBehaviour
{
    public void displayAttack(){
        CombatManager.listOffensiveAttack.SetActive(true);
        CombatManager.listSecretTechnic.SetActive(false);
        CombatManager.inventory.SetActive(false);
    }
}

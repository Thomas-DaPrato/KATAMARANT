using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventory : MonoBehaviour
{
    public void displayInventory(){
        CombatManager.listOffensiveAttack.SetActive(false);
        CombatManager.listSecretTechnic.SetActive(false);
        CombatManager.inventory.SetActive(true);
    }
}

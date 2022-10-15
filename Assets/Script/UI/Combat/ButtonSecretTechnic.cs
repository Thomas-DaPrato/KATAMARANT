using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSecretTechnic : MonoBehaviour
{
   public void displaySecretTechnixc(){
        CombatManager.listOffensiveAttack.SetActive(false);
        CombatManager.listSecretTechnic.SetActive(true);
        CombatManager.inventory.SetActive(false);
   }
}

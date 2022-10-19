using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSecretTechnic : MonoBehaviour
{
   public void displaySecretTechnixc(){
        FightManager.listOffensiveAttack.SetActive(false);
        FightManager.listSecretTechnic.SetActive(true);
        FightManager.inventory.SetActive(false);
   }
}

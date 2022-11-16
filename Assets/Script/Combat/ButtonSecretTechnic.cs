using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSecretTechnic : MonoBehaviour
{
   public void displaySecretTechnixc(){
        FightManager1Vs1.listOffensiveAttack.SetActive(false);
        FightManager1Vs1.listSecretTechnic.SetActive(true);
        FightManager1Vs1.listInventory.SetActive(false);
   }
}

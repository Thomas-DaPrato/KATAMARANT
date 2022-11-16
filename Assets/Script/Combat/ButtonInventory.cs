using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventory : MonoBehaviour
{
    public void displayInventory(){
        FightManager1Vs1.listOffensiveAttack.SetActive(false);
        FightManager1Vs1.listSecretTechnic.SetActive(false);
        FightManager1Vs1.listInventory.SetActive(true);
        FightManager1Vs1.inventoryBag.SetActive(false);
        FightManager1Vs1.inventorySpecialObject.SetActive(false);
    }
}

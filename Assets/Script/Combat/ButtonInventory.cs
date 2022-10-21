using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventory : MonoBehaviour
{
    public void displayInventory(){
        FightManager.listOffensiveAttack.SetActive(false);
        FightManager.listSecretTechnic.SetActive(false);
        FightManager.inventory.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOffensiveActions : MonoBehaviour
{
    public void displayAttack(){
        FightManager1Vs1.listOffensiveAttack.SetActive(true);
        FightManager1Vs1.listSecretTechnic.SetActive(false);
        FightManager1Vs1.listInventory.SetActive(false);
    }
}

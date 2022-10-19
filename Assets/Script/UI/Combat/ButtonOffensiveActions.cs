using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOffensiveActions : MonoBehaviour
{
    public void displayAttack(){
        FightManager.listOffensiveAttack.SetActive(true);
        FightManager.listSecretTechnic.SetActive(false);
        FightManager.inventory.SetActive(false);
    }
}
